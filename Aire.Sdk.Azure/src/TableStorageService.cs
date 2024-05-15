using System.Linq.Expressions;
using System.Reflection;
using Azure;
using Azure.Data.Tables;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Azure
{
    public class TableStorageService : ITableStorageService
    {
        private readonly TableServiceClient client;
        private readonly ILogger<TableStorageService> log;

        public TableStorageService(TableServiceClient client, ILogger<TableStorageService> log)
        {
            this.client = client;
            this.log = log;
        }

        private static string? GetEntityTableName(Type t)
        {
            var attr = t.GetCustomAttribute(typeof(EntityTableAttribute));
            if (attr == null)
                return null;
            return ((EntityTableAttribute)attr).TableName;
        }

        private async Task<TableClient> GetTableClientAsync(Type t)
        {
            var tableName = GetEntityTableName(t);

            if (string.IsNullOrWhiteSpace(tableName))
            {
                log.LogCritical("The table entity '{t}' does not have an EntityTable attribute", t);

                throw new ArgumentException(
                    $"The table entity of type '{t}' is missing attribute '{nameof(EntityTableAttribute)}'!",
                    nameof(t));
            }

            var table = client.GetTableClient(tableName);
            await table.CreateIfNotExistsAsync();
            return table;
        }

        public async Task<List<T>> All<T>() where T : class, ITableEntity, new()
        {
            var client = await GetTableClientAsync(typeof(T));
            return await client.QueryAsync<T>().ToListAsync();
        }

        public async Task<List<T>> Partition<T>(string partitionKey) where T : class, ITableEntity, new()
        {
            var client = await GetTableClientAsync(typeof(T));
            return await client.QueryAsync<T>(x => x.PartitionKey == partitionKey).ToListAsync();
        }

        public async Task<T?> RetrieveAsync<T>(string key) where T : class, ITableEntity, new()
        {
            return await RetrieveAsync<T>(key, key);
        }

        public async Task<T?> RetrieveAsync<T>(string partitionKey, string rowKey) where T : class, ITableEntity, new()
        {
            var client = await GetTableClientAsync(typeof(T));
            var response = await client.GetEntityIfExistsAsync<T>(partitionKey, rowKey);

            if (response.HasValue)
                return response.Value;

            return null;
        }

        public async Task<bool> UpsertAsync<T>(T entity) where T : class, ITableEntity, new()
        {
            var client = await GetTableClientAsync(typeof(T));
            var response = await client.UpsertEntityAsync(entity, TableUpdateMode.Merge);

            if (response.IsError)
                log.LogError("Failed to upsert entity: {status} {reason}", response.Status, response.ReasonPhrase);

            return !response.IsError;
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : class, ITableEntity, new()
        {
            return await DeleteAsync<T>(entity.PartitionKey, entity.RowKey);
        }

        public async Task<bool> DeleteAsync<T>(string partitionKey, string rowKey) where T : class, ITableEntity, new()
        {
            var client = await GetTableClientAsync(typeof(T));
            var response = await client.DeleteEntityAsync(partitionKey, rowKey);

            if (response.IsError)
                log.LogError("Failed to delete entity: {status} {reason}", response.Status, response.ReasonPhrase);

            return !response.IsError;
        }

        public async Task<AsyncPageable<T>> QueryAsync<T>(Expression<Func<T, bool>> expression) where T : class, ITableEntity, new()
        {
            var client = await GetTableClientAsync(typeof(T));
            return client.QueryAsync(expression);
        }

        public async Task<AsyncPageable<T>> QueryAsync<T>(string filter) where T : class, ITableEntity, new()
        {
            var client = await GetTableClientAsync(typeof(T));
            return client.QueryAsync<T>(filter);
        }
    }
}