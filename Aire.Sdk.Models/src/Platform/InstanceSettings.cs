using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace Aire.Sdk.Models.Platform;

public class InstanceSettings
{
    [JsonProperty("inactivityDuration")]
    [Range(5, 720, ErrorMessage = "inactivityDuration must be between 5 and 720 minutes.")]
    public int? InactivityDuration { get; set; }
}
