// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Aire.Sdk.Models.Audit;

namespace Aire.Sdk.Audit;

public interface IAireAuditService
{
    Task<bool> LogEvent(AireAuditResource resource, string userId, string operation, Dictionary<string, dynamic?>? data = null);
    Task<AuditLog> GetAuditLog(AireAuditResource? resource = null, DateTime? from = null, DateTime? to = null);
}
