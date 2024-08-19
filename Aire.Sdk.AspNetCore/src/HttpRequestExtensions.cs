// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.AspNetCore.Http;
using Aire.Sdk.Helpers;

namespace Aire.Sdk.AspNetCore
{
    public static class HttpRequestExtensions
    {
        public static async Task<T?> ReadJson<T>(this HttpRequest req)
        {
            if (req.ContentType == "application/json" && req.Body != null)
            {
                try
                {
                    var reader = new StreamReader(req.Body);
                    string body = await reader.ReadToEndAsync();
                    return body.JsonToObject<T>();
                }
                catch (Exception) { }
            }
            return default;
        }

        public static string? ReadParam(this HttpRequest req, string param)
        {
            string? value = req.Query[param];
            if(value == null && req.HasFormContentType)
                value = req.Form[param];
            return value;
        }

        public static async Task<T?> ReadJsonResponse<T>(this HttpResponseMessage response) where T : new()
        {
            if (response.Content != null)
            {
                var body = await response.Content.ReadAsStringAsync();
                return body.JsonToObject<T>();
            }
            return default;
        }
    }
}
