using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Strava.WebApp.Http;

/// <summary>
/// DelegatingHandler that injects Bearer token and refreshes it if expired/about to expire.
/// Uses auth tokens stored by the Cookie + OAuth handler.
/// </summary>
public sealed class TokenRefreshingHandler(IHttpContextAccessor accessor) : DelegatingHandler
{
    /// <summary>
    /// How long before token expiry should we refresh the token?
    /// </summary>
    private readonly TimeSpan _refreshBeforeExpire = TimeSpan.FromMinutes(5);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var http = accessor.HttpContext;
        if (http is null) return await base.SendAsync(request, ct);

        var tokens = await http.GetTokenAsync("access_token");
        var expiresAt = await http.GetTokenAsync("expires_at"); // unix seconds (string)
        var refreshToken = await http.GetTokenAsync("refresh_token");

        if (string.IsNullOrEmpty(tokens) || IsExpiringSoon(expiresAt))
        {
            // refresh
            var client = new HttpClient { BaseAddress = new Uri("https://www.strava.com/") };
            var cfg = http.RequestServices.GetRequiredService<IConfiguration>()
                .GetSection("Authentication:Strava");
            var payload = new FormUrlEncodedContent([
                new KeyValuePair<string,string>("client_id", cfg["ClientId"]!),
                new KeyValuePair<string,string>("client_secret", cfg["ClientSecret"]!),
                new KeyValuePair<string,string>("grant_type", "refresh_token"),
                new KeyValuePair<string,string>("refresh_token", refreshToken!)
            ]);
            var resp = await client.PostAsync("api/v3/oauth/token", payload, ct);
            resp.EnsureSuccessStatusCode();

            using var doc = JsonDocument.Parse(await resp.Content.ReadAsStringAsync(ct));
            var access = doc.RootElement.GetProperty("access_token").GetString();
            var refresh = doc.RootElement.GetProperty("refresh_token").GetString();
            var expAt = doc.RootElement.GetProperty("expires_at").GetInt64().ToString();

            // Update the auth session
            var auth = await http.AuthenticateAsync();
            auth.Properties!.UpdateTokenValue("access_token", access!);
            auth.Properties!.UpdateTokenValue("refresh_token", refresh!);
            auth.Properties!.UpdateTokenValue("expires_at", expAt);
            await http.SignInAsync(auth.Principal!, auth.Properties!);

            tokens = access;
        }

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens);
        return await base.SendAsync(request, ct);

    }

    private bool IsExpiringSoon(string? unixSeconds)
    {
        if (!long.TryParse(unixSeconds, out var s)) return true;
        var expiry = DateTimeOffset.FromUnixTimeSeconds(s);

        //We want to refresh the token before this moment
        var shouldRefreshBefore = expiry.Subtract(_refreshBeforeExpire);

        return DateTimeOffset.UtcNow >= shouldRefreshBefore;
    }
}