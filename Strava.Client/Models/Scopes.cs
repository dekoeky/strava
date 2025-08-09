namespace Strava.Client.Models;

public static class Scopes
{
    public const char Delimiter = ',';

    /// <summary>
    /// read public segments, public routes, public profile data, public posts, public events, club feeds, and leaderboards.
    /// </summary>
    public const string Read = "read";

    /// <summary>
    /// read private routes, private segments, and private events for the user.
    /// </summary>
    public const string ReadAll = "read_all";

    /// <summary>
    /// read all profile information even if the user has set their profile visibility to Followers or Only You.
    /// </summary>
    public const string ProfileReadAll = "profile:read_all";

    /// <summary>
    /// update the user's weight and Functional Threshold Power (FTP), and access to star or unstar segments on their behalf.
    /// </summary>
    public const string ProfileWrite = "profile:write";

    /// <summary>
    ///  read the user's activity data for activities that are visible to Everyone and Followers, excluding privacy zone data.
    /// </summary>
    public const string ActivityRead = "activity:read";

    /// <summary>
    /// the same access as activity:read, plus privacy zone data and access to read the user's activities with visibility set to Only You.
    /// </summary>
    public const string ActivityReadAll = "activity:read_all";

    /// <summary>
    /// access to create manual activities and uploads, and access to edit any activities that are visible to the app, based on activity read access level.
    /// </summary>
    public const string ActivityWrite = "activity:write";
}