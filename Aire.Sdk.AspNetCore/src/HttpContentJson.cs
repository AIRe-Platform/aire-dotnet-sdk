// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Net.Mime;
using System.Text;
using Aire.Sdk.Helpers;

namespace Aire.Sdk.AspNetCore;

public class JsonContent<T> : StringContent 
{
    public JsonContent(T obj) 
        : base(obj.ObjectToJson(), Encoding.UTF8, MediaTypeNames.Application.Json)
    { }
}
