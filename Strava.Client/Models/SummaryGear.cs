using System.Text.Json.Serialization;

namespace Strava.Client.Models;

public class SummaryGear
{
    /// <summary>
    /// The gear's unique identifier.
    /// </summary>
    [JsonPropertyName("id")] public long Id { get; set; }

    /// <summary>
    /// Resource state, indicates level of detail.
    /// </summary>
    [JsonPropertyName("resource_state")] public ResourceState ResourceState { get; set; }

    /// <summary>
    /// Whether this gear's is the owner's default one.
    /// </summary>
    [JsonPropertyName("primary")] public bool Primary { get; set; }


    /// <summary>
    /// The gear's name.
    /// </summary>
    [JsonPropertyName("name")] public bool Name { get; set; }

    /// <summary>
    /// The distance logged with this gear.
    /// </summary>
    [JsonPropertyName("distance")] public float Distance { get; set; }
}