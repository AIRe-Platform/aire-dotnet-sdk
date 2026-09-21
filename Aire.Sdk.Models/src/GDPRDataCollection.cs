// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models.Chat;
using Aire.Sdk.Models.Identity;
using Aire.Sdk.Models.Resources;
using Aire.Sdk.Models.Statistics;
using Newtonsoft.Json;

namespace Aire.Sdk.Models;

/// <summary>
/// Contains all user data in Memory service module
/// </summary>
public class GDPRMemoryDataCollection
{
    [JsonProperty("chats")]
    public List<ChatLogMetadata>? Chats { get; set; }

    [JsonProperty("chatlogs")]
    public Dictionary<string, ChatLog>? Chatlogs { get; set; }

    [JsonProperty("questionnaires")]
    public List<QuestionnaireResults>? Questionnaires { get; set; }

    [JsonProperty("public_questionnaires")]
    public List<QuestionnaireResults>? PublicQuestionnaires { get; set; }

    [JsonProperty("reminders")]
    public List<Reminder>? Reminders { get; set; }

    [JsonProperty("content_votes")]
    public List<ContentVote>? ContentVotes { get; set; }

    [JsonProperty("stats")]
    public List<StatisticsEvent>? Statistics { get; set; }
}

/// <summary>
/// Object containing all user data gathered by the service
/// </summary>
public class GDPRDataCollection
{
    [JsonProperty("profile")]
    public User? Profile { get; set; }

    [JsonProperty("memory")]
    public Dictionary<string, GDPRMemoryDataCollection>? Memory { get; set; } = [];
}
