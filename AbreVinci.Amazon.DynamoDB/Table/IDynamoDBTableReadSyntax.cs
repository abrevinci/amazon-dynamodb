// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table.BatchRead;
using AbreVinci.Amazon.DynamoDB.Table.Query;
using AbreVinci.Amazon.DynamoDB.Table.Scan;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table
{
    [PublicAPI]
    public interface IDynamoDBTableReadSyntax
    {
        /// <summary>
        /// Adds the given attributes to the projection expression for consecutive read operations.
        /// </summary>
        /// <param name="attributes">The attributes to project.</param>
        /// <returns>A continuation context that allows setting up and executing per-table non-transaction read requests (now with the selected projection).</returns>
        /// <example>
        /// <code>
        /// var item = await table.IncludeAttributes("id", "value").GetAsync(hashKey);
        /// </code>
        /// </example>
        IDynamoDBTableReadSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);

        /// <see cref="IncludeAttributes(DynamoDBAttributePath[])"/>
        IDynamoDBTableReadSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes);

        /// <summary>
        /// Gets the item with the given hash key.
        /// </summary>
        /// <param name="hashKey">The hash key to look for.</param>
        /// <returns>An awaitable task that resolves to the retrieved item, or null if it is not found.</returns>
        /// <seealso cref="GetAsync(DynamoDBKeyValue, DynamoDBKeyValue)"/>
        /// <example>
        /// <code>
        /// var item = await table.GetAsync(hashKey);
        /// </code>
        /// </example>
        Task<DynamoDBMap> GetAsync(DynamoDBKeyValue hashKey);

        /// <summary>
        /// Gets the item with the given composite (hash+range) key.
        /// </summary>
        /// <param name="hashKey">The hash key to look for.</param>
        /// <param name="rangeKey">The range key to look for.</param>
        /// <returns>An awaitable task that resolves to the retrieved item, or null if it is not found.</returns>
        /// <seealso cref="GetAsync(DynamoDBKeyValue)"/>
        /// <example>
        /// <code>
        /// var item = await table.GetAsync(hashKey, rangeKey);
        /// </code>
        /// </example>
        Task<DynamoDBMap> GetAsync(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey);

        IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue hashKey);
        IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue hashKey, DynamoDBKeyConditionExpression keyConditionExpression);

        IDynamoDBTableScanSyntax Scan();

        IDynamoDBTableBatchReadSyntax BatchRead();
    }
}