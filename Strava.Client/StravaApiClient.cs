using Strava.Client.Json;
using Strava.Client.Models;
using System.Net.Http.Json;

namespace Strava.Client
{
    public class StravaApiClient(HttpClient client)
    {
        private const string DefaultBaseUrl = "https://www.strava.com/api/v3/";
        private static readonly Uri DefaultBaseUri = new(DefaultBaseUrl);

        public StravaApiClient() : this(CreateDefaultClient())
        {
        }

        private static HttpClient CreateDefaultClient() => new() { BaseAddress = DefaultBaseUri, };

        public Task<DetailedAthlete> GetLoggedInAthlete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List Athlete Activities.
        /// </summary>
        /// <remarks>
        /// Returns the activities of an athlete for a specific identifier.
        /// Requires activity:read.
        /// Only Me activities will be filtered out unless requested by a token with activity:read_all.
        /// </remarks>
        /// <param name="before">An epoch timestamp to use for filtering activities that have taken place before a certain time.</param>
        /// <param name="after">An epoch timestamp to use for filtering activities that have taken place after a certain time.</param>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public Task<SummaryActivity[]?> GetLoggedInAthleteActivities(DateTime? before = null,
            DateTime? after = null,
            int? page = null,
            int? perPage = null,
            CancellationToken cancellationToken = default)
        {
            var path = "athlete/activities?";

            if (before.HasValue) path += $"before={before.Value.ToUnixTimeSeconds()}&";
            if (after.HasValue) path += $"after={after.Value.ToUnixTimeSeconds()}&";
            if (page.HasValue) path += $"page={page.Value}&";
            if (perPage.HasValue) path += $"per_page={perPage.Value}&";

            //Cut away the last symbol
            path = path[..^1];

            return client.GetFromJsonAsync<SummaryActivity[]>(path, SourceGenerationContext.Default.SummaryActivityArray, cancellationToken);
        }
    }
}
