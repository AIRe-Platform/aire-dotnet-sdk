// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Azure.Data.Tables;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Azure;

public class TableStorageServiceFactory(TableServiceClient client, ILoggerFactory loggerFactory)
    : ITableStorageServiceFactory
{
    public ITableStorageService Create(string tablePrefix)
    {
        var logger = loggerFactory.CreateLogger<TableStorageService>();
        return new TableStorageService(client, logger, tablePrefix);
    }
}
