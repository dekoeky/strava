using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Options;
using Strava.Client.Models;
using System.Text.Encodings.Web;

namespace Strava.WebApp.OAuth;

public sealed class StravaOAuthHandler(
    IOptionsMonitor<OAuthOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder)
    : OAuthHandler<OAuthOptions>(options, logger, encoder)
{
    // Strava wants comma-separated scopes
    protected override string FormatScope(IEnumerable<string> scopes)
        => string.Join(Scopes.Delimiter, scopes);
}