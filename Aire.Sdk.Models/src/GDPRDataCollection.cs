// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models.Chat;
using Aire.Sdk.Models.Identity;
using Aire.Sdk.Models.Resources;
using Newtonsoft.Json;

namespace Aire.Sdk.Models;

/// <summary>
/// Object containing all user data gathered by the service
/// </summary>
public class GDPRDataCollection : Dictionary<string, object?>
{
    [JsonProperty("profile")]
    public User? Profile
    {
        get => GetTyped<User>("profile");
        set => this["profile"] = value;
    }

    [JsonProperty("chats")]
    public List<ChatLogMetadata>? Chats
    {
        get => GetTyped<List<ChatLogMetadata>>("chats");
        set => this["chats"] = value;
    }

    [JsonProperty("chatlogs")]
    public Dictionary<string, ChatLog>? Chatlogs
    {
        get => GetTyped<Dictionary<string, ChatLog>>("chatlogs");
        set => this["chatlogs"] = value;
    }

    [JsonProperty("questionnaires")]
    public List<QuestionnaireResults>? Questionnaires
    {
        get => GetTyped<List<QuestionnaireResults>>("questionnaires");
        set => this["questionnaires"] = value;
    }

    public T? GetTyped<T>(string key) where T : class, new()
    {
        try
        {
            var obj = this[key];
            if (obj != null && obj is T)
                return obj as T;
        }
        catch (Exception) { }

        return null;
    }
}
