// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Azure;
using Azure.Data.Tables;

namespace Aire.Sdk.Azure;

public class BaseTableEntity : ITableEntity
{
    public virtual string? PartitionKey { get; set; }
    public virtual string? RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}

