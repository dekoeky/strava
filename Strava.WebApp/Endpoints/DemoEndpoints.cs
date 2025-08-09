using Microsoft.AspNetCore.Mvc;

namespace Strava.WebApp.Endpoints;

public static class DemoEndpoints
{
    public static void MapDataEndpoints(this WebApplication webApplication)
    {
        // API: current athlete (requires login)
        webApplication.MapGet("/api/me", async ([FromServices] IHttpClientFactory f, HttpContext http) =>
        {
            //http.RequireAuthorization();
            var c = f.CreateClient("StravaApi");
            var res = await c.GetAsync("athlete");
            res.EnsureSuccessStatusCode();
            return Results.Stream(await res.Content.ReadAsStreamAsync(), "application/json");
        }).RequireAuthorization();

        // API: recent activities
        webApplication.MapGet("/api/activities", async ([FromServices] IHttpClientFactory f, HttpContext http, int page = 1, int perPage = 30) =>
        {
            //http.RequireAuthorization();
            var c = f.CreateClient("StravaApi");
            var res = await c.GetAsync($"athlete/activities?page={page}&per_page={perPage}");
            res.EnsureSuccessStatusCode();
            return Results.Stream(await res.Content.ReadAsStreamAsync(), "application/json");
        }).RequireAuthorization();
    }
}