// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Aire.Sdk.AspNetCore
{
    public class ForbiddenResult : StatusCodeResult
    {
        public ForbiddenResult() : base((int) HttpStatusCode.Forbidden) {}
    }

    public class ForbiddenObjectResult : ObjectResult
    {
        public ForbiddenObjectResult(object obj) : base(obj)
        {
            StatusCode = (int) HttpStatusCode.Forbidden;
        }
    }
}
