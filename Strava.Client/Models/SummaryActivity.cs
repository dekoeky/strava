using System.Text.Json.Serialization;

namespace Strava.Client.Models;
/// <summary>
/// Represents a summary of a Strava activity.
/// </summary>
public class SummaryActivity
{
    /// <summary>
    /// The unique identifier of the activity
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// The identifier provided at upload time
    /// </summary>
    [JsonPropertyName("external_id")]
    public string ExternalId { get; set; }

    /// <summary>
    /// The identifier of the upload that resulted in this activity
    /// </summary>
    [JsonPropertyName("upload_id")]
    public long UploadId { get; set; }

    /// <summary>
    /// An instance of MetaAthlete
    /// </summary>
    [JsonPropertyName("athlete")]
    public MetaAthlete Athlete { get; set; }

    /// <summary>
    /// The name of the activity
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The activity's distance, in meters
    /// </summary>
    [JsonPropertyName("distance")]
    public float Distance { get; set; }

    /// <summary>
    /// The activity's moving time, in seconds
    /// </summary>
    [JsonPropertyName("moving_time")]
    public int MovingTime { get; set; }

    /// <summary>
    /// The activity's elapsed time, in seconds
    /// </summary>
    [JsonPropertyName("elapsed_time")]
    public int ElapsedTime { get; set; }

    /// <summary>
    /// The activity's total elevation gain
    /// </summary>
    [JsonPropertyName("total_elevation_gain")]
    public float TotalElevationGain { get; set; }

    /// <summary>
    /// The activity's highest elevation, in meters
    /// </summary>
    [JsonPropertyName("elev_high")]
    public float ElevHigh { get; set; }

    /// <summary>
    /// The activity's lowest elevation, in meters
    /// </summary>
    [JsonPropertyName("elev_low")]
    public float ElevLow { get; set; }

    /// <summary>
    /// Deprecated. Prefer to use sport_type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The type of sport for the activity
    /// </summary>
    [JsonPropertyName("sport_type")]
    public SportType SportType { get; set; }

    /// <summary>
    /// The time at which the activity was started
    /// </summary>
    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// The time at which the activity was started in the local timezone
    /// </summary>
    [JsonPropertyName("start_date_local")]
    public DateTime StartDateLocal { get; set; }

    /// <summary>
    /// The timezone of the activity
    /// </summary>
    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    /// <summary>
    /// An instance of LatLng for start location
    /// </summary>
    [JsonPropertyName("start_latlng")]
    public float[] StartLatLng { get; set; }

    /// <summary>
    /// An instance of LatLng for end location
    /// </summary>
    [JsonPropertyName("end_latlng")]
    public float[] EndLatLng { get; set; }

    /// <summary>
    /// The number of achievements gained during this activity
    /// </summary>
    [JsonPropertyName("achievement_count")]
    public int AchievementCount { get; set; }

    /// <summary>
    /// The number of kudos given for this activity
    /// </summary>
    [JsonPropertyName("kudos_count")]
    public int KudosCount { get; set; }

    /// <summary>
    /// The number of comments for this activity
    /// </summary>
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }

    /// <summary>
    /// The number of athletes taking part in a group activity
    /// </summary>
    [JsonPropertyName("athlete_count")]
    public int AthleteCount { get; set; }

    /// <summary>
    /// The number of Instagram photos for this activity
    /// </summary>
    [JsonPropertyName("photo_count")]
    public int PhotoCount { get; set; }

    /// <summary>
    /// The number of Instagram and Strava photos for this activity
    /// </summary>
    [JsonPropertyName("total_photo_count")]
    public int TotalPhotoCount { get; set; }

    /// <summary>
    /// An instance of PolylineMap
    /// </summary>
    [JsonPropertyName("map")]
    public PolylineMap Map { get; set; }

    /// <summary>
    /// Whether this activity was recorded on a training machine
    /// </summary>
    [JsonPropertyName("trainer")]
    public bool Trainer { get; set; }

    /// <summary>
    /// Whether this activity is a commute
    /// </summary>
    [JsonPropertyName("commute")]
    public bool Commute { get; set; }

    /// <summary>
    /// Whether this activity was created manually
    /// </summary>
    [JsonPropertyName("manual")]
    public bool Manual { get; set; }

    /// <summary>
    /// Whether this activity is private
    /// </summary>
    [JsonPropertyName("private")]
    public bool Private { get; set; }

    /// <summary>
    /// Whether this activity is flagged
    /// </summary>
    [JsonPropertyName("flagged")]
    public bool Flagged { get; set; }

    /// <summary>
    /// The activity's workout type
    /// </summary>
    [JsonPropertyName("workout_type")]
    public int? WorkoutType { get; set; }

    /// <summary>
    /// The unique identifier of the upload in string format
    /// </summary>
    [JsonPropertyName("upload_id_str")]
    public string UploadIdStr { get; set; }

    /// <summary>
    /// The activity's average speed, in meters per second
    /// </summary>
    [JsonPropertyName("average_speed")]
    public float AverageSpeed { get; set; }

    /// <summary>
    /// The activity's max speed, in meters per second
    /// </summary>
    [JsonPropertyName("max_speed")]
    public float MaxSpeed { get; set; }

    /// <summary>
    /// Whether the logged-in athlete has kudoed this activity
    /// </summary>
    [JsonPropertyName("has_kudoed")]
    public bool HasKudoed { get; set; }

    /// <summary>
    /// Whether the activity is muted
    /// </summary>
    [JsonPropertyName("hide_from_home")]
    public bool HideFromHome { get; set; }

    /// <summary>
    /// The id of the gear for the activity
    /// </summary>
    [JsonPropertyName("gear_id")]
    public string GearId { get; set; }

    /// <summary>
    /// The total work done in kilojoules during this activity (rides only)
    /// </summary>
    [JsonPropertyName("kilojoules")]
    public float? Kilojoules { get; set; }

    /// <summary>
    /// Average power output in watts during this activity (rides only)
    /// </summary>
    [JsonPropertyName("average_watts")]
    public float? AverageWatts { get; set; }

    /// <summary>
    /// Whether the watts are from a power meter (false if estimated)
    /// </summary>
    [JsonPropertyName("device_watts")]
    public bool? DeviceWatts { get; set; }

    /// <summary>
    /// Maximum power output (rides with power meter data only)
    /// </summary>
    [JsonPropertyName("max_watts")]
    public int? MaxWatts { get; set; }

    /// <summary>
    /// Weighted average power (normalized power, rides with power meter only)
    /// </summary>
    [JsonPropertyName("weighted_average_watts")]
    public int? WeightedAverageWatts { get; set; }
}