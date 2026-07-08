// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Aire.Sdk.Azure;
using Aire.Sdk.Models.Audit;
using Azure.Data.Tables;
using Microsoft.Extensions.Options;

namespace Aire.Sdk.Audit;

public class AireAuditService(
    IOptions<AireAuditServiceOptions> options,
    ITableStorageService storage
) : IAireAuditService
{
    private readonly string table = options.Value.AuditEventTable ?? "AuditEvents";
    private readonly string source = options.Value.Source ?? "";

    public async Task<AuditLog> GetAuditLog(AireAuditResource? resource = null, DateTime? from = null, DateTime? to = null)
    {
        var client = await storage.GetTableClient(table);
        string filter = CreateFilter(resource, from, to);
        var results = await client.QueryAsync<TableEntity>(filter).ToListAsync();
        var events = results.OrderBy(x => x.Timestamp).Select(EntityToModel).ToList();

        var log = new AuditLog()
        {
            Start = from ?? events.FirstOrDefault()?.Timestamp?.ToUniversalTime(),
            End = to ?? events.LastOrDefault()?.Timestamp?.ToUniversalTime(),
            Sources = [source],
            Events = [.. events.Select(x => x.ToDictionary())]
        };

        return log;
    }

    public async Task<bool> LogEvent(AireAuditResource resource, string userId, string operation, Dictionary<string, dynamic?>? data)
    {
        var eventData = new AuditEvent(data ?? [])
        {
            Source = source,
            UserId = userId,
            Operation = operation
        };

        var entity = new TableEntity(eventData.ToDictionary())
        {
            PartitionKey = resource.ToString(),
            RowKey = Guid.NewGuid().ToString()
        };

        var client = await storage.GetTableClient(table);
        var result = await client.AddEntityAsync(entity);

        return !result.IsError;
    }

    private string CreateFilter(AireAuditResource? resource = null, DateTime? from = null, DateTime? to = null)
    {
        List<string> filters = [$"source eq '{source}'"];

        if (resource != null)
            filters.Add(resource.CreateFilter("PartitionKey"));

        if (from.HasValue)
            filters.Add($"Timestamp ge datetime'{from.Value.Date.ToUniversalTime():O}'");

        if (to.HasValue)
            filters.Add($"Timestamp lt datetime'{to.Value.Date.AddDays(1).ToUniversalTime():O}'");

        return string.Join(" and ", filters);
    }

    private static AuditEvent EntityToModel(TableEntity entity)
    {
        string[] skip = ["RowKey", "PartitionKey", "odata.etag", "ETag", "Timestamp"];

        var data = new Dictionary<string, dynamic?>();
        foreach (var key in entity.Keys)
        {
            if (skip.Contains(key))
                continue;

            data[key] = entity[key];
        }

        var model = new AuditEvent(data)
        {
            Resource = entity.PartitionKey,
            EventId = Guid.Parse(entity.RowKey),
            Timestamp = entity.Timestamp?.UtcDateTime,
        };

        return model;
    }
}
