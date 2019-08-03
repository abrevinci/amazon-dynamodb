// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Expressions.Update;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table.BatchWrite;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table
{
    [PublicAPI]
    public interface IDynamoDBTableWriteSyntax
    {
        /// <summary>
        /// Saves the given item.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <param name="returnOldItem">Whether or not to return the old item as it was stored before the put (if it existed).</param>
        /// <returns>An awaitable task that resolves to the old item if requested and it existed, or null otherwise.</returns>
        /// <example>
        /// <code>
        /// await table.PutAsync(item1);
        /// var oldItem = await table.PutAsync(item2, true);
        /// </code>
        /// </example>
        Task<DynamoDBMap> PutAsync(DynamoDBMap item, bool returnOldItem = false);

        Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue partitionKey, bool returnDeletedItem = false);
        Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey, bool returnDeletedItem = false);

        Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None);
        Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None);

        IDynamoDBTableBatchWriteSyntax BatchWrite();
    }
}