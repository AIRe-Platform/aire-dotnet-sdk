// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace Aire.Sdk.Models.Platform;

public class InstanceSettings
{
    [JsonProperty("inactivityDuration")]
    [Range(5, 720, ErrorMessage = "inactivityDuration must be between 5 and 720 minutes.")]
    [OpenApiProperty(Description = "The inactivity duration before a user is automatically logged out.")]
    public int? InactivityDuration { get; set; }
}
