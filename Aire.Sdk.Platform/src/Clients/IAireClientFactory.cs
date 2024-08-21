// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


namespace Aire.Sdk.Platform.Clients;

public interface IAireClientFactory
{
    public Task<IAireAiClient?> CreateAiClient(string? accessToken = null, string? serviceName = null);
    public Task<IAireMemoryClient?> CreateMemoryClient(string? accessToken = null, string? serviceName = null);
}
