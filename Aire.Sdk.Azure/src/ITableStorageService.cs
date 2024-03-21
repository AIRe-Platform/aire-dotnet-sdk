using System.Linq.Expressions;
using Azure;
using Azure.Data.Tables;

namespace Aire.Sdk.Azure
{
    public interface ITableStorageService 
    {
        /// <summary>
        /// Retrieve all entities
        /// </summary>
        /// <typeparam name="T">Entity class</typeparam>
        /// <returns>List of entities</returns>
        Task<List<T>> All<T>()
            where T: class, ITableEntity, new();

        /// <summary>
        /// Retrieves an entity using the key as both the partition key and row key
        /// </summary>
        /// <typeparam name="T">Entity class</typeparam>
        /// <param name="key">PartitionKey/RowKey</param>
        /// <returns>Entity object if found, otherwise null</returns>
        Task<T?> RetrieveAsync<T>(string key)
            where T: class, ITableEntity, new();
            
        /// <summary>
        /// Retrieves an entity using a partition key and a row key
        /// </summary>
        /// <typeparam name="T">Entity class</typeparam>
        /// <param name="partitionKey">Partition key</param>
        /// <param name="rowKey">Row key</param>
        /// <returns>Entity object if foudn, otherwise null</returns>
        Task<T?> RetrieveAsync<T>(string partitionKey, string rowKey) 
            where T: class, ITableEntity, new();

        /// <summary>
        /// Inserts or updates an entity.
        /// If the entity exists, merges the entity with the existing one.
        /// </summary>
        /// <typeparam name="T">Entity class</typeparam>
        /// <param name="entity">Entity object</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpsertAsync<T>(T entity)
            where T: class, ITableEntity, new();
            
        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <typeparam name="T">Entity class</typeparam>
        /// <param name="entity">Entity object</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteAsync<T>(T entity)
            where T: class, ITableEntity, new();

        /// <summary>
        /// Finds and deletes an entity
        /// </summary>
        /// <typeparam name="T">Entity class</typeparam>
        /// <param name="partitionKey">Partition key</param>
        /// <param name="rowKey">Row key</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteAsync<T>(string partitionKey, string rowKey)
            where T: class, ITableEntity, new();

        /// <summary>
        /// Queries entities
        /// </summary>
        /// <typeparam name="T">Entity class</typeparam>
        /// <param name="expression">Query expression</param>
        /// <returns>Async pageable</returns>
        Task<AsyncPageable<T>> QueryAsync<T>(Expression<Func<T, bool>> expression)
            where T: class, ITableEntity, new();
    }
}
