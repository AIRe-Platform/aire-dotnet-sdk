// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


namespace Aire.Sdk.Platform.Clients;

public interface IAireMemoryClient
{
    /// <summary>
    /// Deletes or anonymizes all user data
    /// </summary>
    /// <param name="anonymize">Set to true to anoymize</param>
    /// <returns>True if successful, otherwise false</returns>
    public abstract Task<bool> DeleteUserData(bool anonymize);
}
