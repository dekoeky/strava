using System.Text.Json.Serialization;

namespace Strava.Client.Models;

/// <summary>
/// Represents the map polyline data for an activity
/// </summary>
public class PolylineMap
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("polyline")]
    public string Polyline { get; set; }

    [JsonPropertyName("summary_polyline")]
    public string SummaryPolyline { get; set; }
}