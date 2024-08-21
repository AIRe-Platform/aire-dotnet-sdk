// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Web;

namespace Aire.Sdk.AspNetCore;

public static class QueryString
{
    public static string FromDictionary(Dictionary<string, string?> kvp)
    {
        return "?" + string.Join("&", kvp.Select(x =>
        {
            var param = HttpUtility.UrlEncode(x.Key);
            if (x.Value != null)
                param += "=" + HttpUtility.UrlEncode(x.Value);
            return param;
        }));
    }
}
