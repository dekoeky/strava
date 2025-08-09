using Strava.Client.Models;
using System.Text.Json.Serialization;

namespace Strava.Client.Json;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(DetailedAthlete))]
[JsonSerializable(typeof(SummaryActivity))]
[JsonSerializable(typeof(SummaryActivity[]))]
internal partial class SourceGenerationContext : JsonSerializerContext;