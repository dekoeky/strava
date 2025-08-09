using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Strava.WebApp.Endpoints;

public static class LoginEndpoints
{
    public static void MapLoginEndpoints(this WebApplication webApplication)
    {
        // UI: sign-in/out
        webApplication.MapGet("/login", () => Results.Challenge(new AuthenticationProperties { RedirectUri = "/" }, ["Strava"]));

        webApplication.MapGet("/logout", async (HttpContext http) =>
        {
            await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Redirect("/");
        });
    }
}