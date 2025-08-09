using System.Text.Json.Serialization;

namespace Strava.Client.Models;

/// <summary>
/// Represents a lightweight reference to an athlete
/// </summary>
public class MetaAthlete
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}