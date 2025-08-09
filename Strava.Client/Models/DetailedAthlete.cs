using System.Text.Json.Serialization;

namespace Strava.Client.Models;

public class DetailedAthlete
{
    /// <summary>
    /// The unique identifier of the athlete
    /// </summary>
    [JsonPropertyName("id")] public long Id { get; set; }

    /// <summary>
    /// Resource state, indicates level of detail.
    /// </summary>
    [JsonPropertyName("resource_state")] public ResourceState ResourceState { get; set; }

    /// <summary>
    /// The athlete's first name.
    /// </summary>
    [JsonPropertyName("firstname")] public string FirstName { get; set; }

    /// <summary>
    /// The athlete's last name.
    /// </summary>
    [JsonPropertyName("lastname")] public string LastName { get; set; }

    /// <summary>
    /// URL to a 62x62 pixel profile picture.
    /// </summary>
    [JsonPropertyName("profile_medium")] public string ProfileMedium { get; set; }

    /// <summary>
    /// The athlete's city.
    /// </summary>
    [JsonPropertyName("city")] public string City { get; set; }

    /// <summary>
    /// The athlete's state or geographical region.
    /// </summary>
    [JsonPropertyName("state")] public string State { get; set; }

    /// <summary>
    /// The athlete's country.
    /// </summary>
    [JsonPropertyName("country")] public string Country { get; set; }

    /// <summary>
    /// The athlete's sex. May take one of the following values: M, F
    /// </summary>
    [JsonPropertyName("sex")] public string Sex { get; set; }

    /// <summary>
    /// Deprecated. Use summit field instead. Whether the athlete has any Summit subscription.
    /// </summary>
    [Obsolete("Use summit field instead.")]
    [JsonPropertyName("premium")] public bool Premium { get; set; }

    /// <summary>
    /// Whether the athlete has any Summit subscription.
    /// </summary>
    [JsonPropertyName("summit")] public bool Summit { get; set; }

    /// <summary>
    /// The time at which the athlete was created.
    /// </summary>
    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The time at which the athlete was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The athlete's follower count.
    /// </summary>
    [JsonPropertyName("follower_count")] public string FollowerCount { get; set; }

    /// <summary>
    /// The athlete's friend count.
    /// </summary>
    [JsonPropertyName("friend_count")] public int FriendCount { get; set; }

    /// <summary>
    /// The athlete's preferred unit system. May take one of the following values: feet, meters
    /// </summary>
    [JsonPropertyName("measurement_preference")] public string MeasurementPreference { get; set; }

    /// <summary>
    /// The athlete's FTP (Functional Threshold Power).
    /// </summary>
    [JsonPropertyName("ftp")] public int Ftp { get; set; }

    /// <summary>
    /// The athlete's weight.
    /// </summary>
    [JsonPropertyName("weight")] public float Weight { get; set; }

    /// <summary>
    /// The athlete's clubs.
    /// </summary>
    [JsonPropertyName("clubs")] public SummaryClub Clubs { get; set; }

    /// <summary>
    /// The athlete's bikes.
    /// </summary>
    [JsonPropertyName("bikes")] public SummaryGear Bikes { get; set; }

    /// <summary>
    /// The athlete's shoes.
    /// </summary>
    [JsonPropertyName("shoes")] public SummaryGear Shoes { get; set; }
}