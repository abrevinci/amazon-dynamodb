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
        Task<DynamoDBMap> PutAsync(DynamoDBMap item, bool returnOldItem = false);

        Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue hashKey, bool returnDeletedItem = false);
        Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey, bool returnDeletedItem = false);

        Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue hashKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None);
        Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None);

        IDynamoDBTableBatchWriteSyntax BatchWrite();
    }
}