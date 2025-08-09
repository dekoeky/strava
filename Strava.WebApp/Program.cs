using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Strava.Client.Models;
using Strava.WebApp.Endpoints;
using Strava.WebApp.Http;
using Strava.WebApp.OAuth;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "Strava";
    })
    .AddCookie()
    .AddOAuth<OAuthOptions, StravaOAuthHandler>("Strava", options =>
    {
        var cfg = builder.Configuration.GetSection("Authentication:Strava");
        options.ClientId = cfg["ClientId"]!;
        options.ClientSecret = cfg["ClientSecret"]!;
        options.CallbackPath = cfg["CallbackPath"] ?? "/signin-strava";

        options.AuthorizationEndpoint = Strava.Client.Endpoints.AuthorizationEndpoint;
        options.TokenEndpoint = Strava.Client.Endpoints.TokenEndpoint;
        options.UserInformationEndpoint = Strava.Client.Endpoints.UserInformationEndpoint;

        // Scopes
        foreach (var scope in cfg.GetSection("Scopes").Get<string[]>() ?? [Scopes.Read])
            options.Scope.Add(scope);


        options.SaveTokens = true;

        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, DetailedAthlete.JsonId);
        options.ClaimActions.MapJsonKey(ClaimTypes.Name, DetailedAthlete.JsonUsername);
        options.ClaimActions.MapJsonKey("strava:first_name", DetailedAthlete.JsonFirstName);
        options.ClaimActions.MapJsonKey("strava:last_name", DetailedAthlete.JsonLastName);

        options.Events = new OAuthEvents
        {
            // Fetch athlete profile to fill claims
            OnCreatingTicket = async ctx =>
            {
                using var req = new HttpRequestMessage(HttpMethod.Get, options.UserInformationEndpoint);
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ctx.AccessToken);
                var resp = await ctx.Backchannel.SendAsync(req);
                resp.EnsureSuccessStatusCode();

                using var json = await JsonDocument.ParseAsync(await resp.Content.ReadAsStreamAsync());
                ctx.RunClaimActions(json.RootElement);
            }
        };
    });

builder.Services.AddRazorPages();

// Typed client that auto-refreshes Strava tokens using the current user’s auth session
builder.Services.AddHttpClient("StravaApi", client =>
{
    client.BaseAddress = new Uri("https://www.strava.com/api/v3/");
    //}).AddHttpMessageHandler(() => new TokenRefreshingHandler());
}).AddHttpMessageHandler<TokenRefreshingHandler>();
builder.Services.AddSingleton<TokenRefreshingHandler>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapRazorPages();

app.MapLoginEndpoints();
app.MapDataEndpoints();


app.Run();