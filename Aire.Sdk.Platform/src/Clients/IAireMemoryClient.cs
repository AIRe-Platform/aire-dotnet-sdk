// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models;
using Aire.Sdk.Models.Chat;

namespace Aire.Sdk.Platform.Clients;

public interface IAireMemoryClient
{
    /// <summary>
    /// Get list of chatlogs
    /// </summary>
    /// <returns>List of chatlogs</returns>
    public abstract Task<List<ChatLogMetadata>?> GetChatHistory();

    /// <summary>
    /// Get chatlog
    /// </summary>
    /// <param name="id">Chatlog ID</param>
    /// <returns>Chatlog object</returns>
    public abstract Task<ChatLog?> GetChatlog(string id);

    /// <summary>
    /// Deletes or anonymizes all user data
    /// </summary>
    /// <param name="anonymize">Set to true to anoymize</param>
    /// <returns>True if successful, otherwise false</returns>
    public abstract Task<bool> DeleteUserData(bool anonymize);

    /// <summary>
    /// Request all data containing personally identifiable information of the current user
    /// </summary>
    /// <returns>Data collection object</returns>
    public abstract Task<GDPRMemoryDataCollection?> GetUserData();
}
