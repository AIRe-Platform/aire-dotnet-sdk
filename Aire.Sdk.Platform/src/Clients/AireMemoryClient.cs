// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.AspNetCore;
using Aire.Sdk.Models.Platform;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Platform.Clients;

public class AireMemoryClient : AireClientBase, IAireMemoryClient
{
    private readonly ILogger<AireMemoryClient> _log;

    public AireMemoryClient(HttpClient httpclient, Module serviceModule, string? accessToken, ILogger<AireMemoryClient> log) 
        : base(httpclient, serviceModule, accessToken)
    {
        _log = log;
    }

    public async Task<bool> DeleteUserData(bool anonymize)
    {
        var query = new Dictionary<string, string?> {
            { "anonymize", anonymize ? "1" : "0" }
        };

        string path = "v1/user-data" + QueryString.FromDictionary(query);
        var req = new HttpRequestMessage(HttpMethod.Delete, path);
        var response = await _httpClient.SendAsync(req);

        await LogIfErrorResponse(response, _log);
        return response.IsSuccessStatusCode;
    }
}
