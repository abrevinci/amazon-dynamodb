// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Expressions.Update;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.If
{
    [PublicAPI]
    public interface IDynamoDBTableConditionalWriteSyntax
    {
        Task<bool> TryPutAsync(DynamoDBMap item);
        Task<bool> TryPutAsync(DynamoDBMap item, Out<DynamoDBMap> oldItem);

        Task<bool> TryDeleteAsync(DynamoDBKeyValue partitionKey);
        Task<bool> TryDeleteAsync(DynamoDBKeyValue partitionKey, Out<DynamoDBMap> deletedItem);
        Task<bool> TryDeleteAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey);
        Task<bool> TryDeleteAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey, Out<DynamoDBMap> deletedItem);

        Task<bool> TryUpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBUpdateExpression updateExpression);
        Task<bool> TryUpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue, Out<DynamoDBKeyValue> returnedItem);
        Task<bool> TryUpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey, DynamoDBUpdateExpression updateExpression);
        Task<bool> TryUpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue, Out<DynamoDBKeyValue> returnedItem);
    }
}