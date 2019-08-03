// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.BatchWrite;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.BatchWrite
{
    [PublicAPI]
    public interface IDynamoDBTableBatchWriteSyntax
    {
        IDynamoDBBatchWriteTerminationSyntax Put(DynamoDBMap item);
        IDynamoDBBatchWriteTerminationSyntax Put(params DynamoDBMap[] items);
        IDynamoDBBatchWriteTerminationSyntax Put(IEnumerable<DynamoDBMap> items);

        IDynamoDBBatchWriteTerminationSyntax Delete(DynamoDBKeyValue partitionKey);
        IDynamoDBBatchWriteTerminationSyntax Delete(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey);
        IDynamoDBBatchWriteTerminationSyntax Delete(params DynamoDBKeyValue[] partitionKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(IEnumerable<DynamoDBKeyValue> partitionKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(params (DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)[] compositeKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(IEnumerable<(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)> compositeKeys);
    }
}