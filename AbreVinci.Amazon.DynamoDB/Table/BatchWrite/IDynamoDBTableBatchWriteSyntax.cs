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

        IDynamoDBBatchWriteTerminationSyntax Delete(DynamoDBKeyValue hashKey);
        IDynamoDBBatchWriteTerminationSyntax Delete(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey);
        IDynamoDBBatchWriteTerminationSyntax Delete(params DynamoDBKeyValue[] hashKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(IEnumerable<DynamoDBKeyValue> hashKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(params (DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey)[] compositeKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(IEnumerable<(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey)> compositeKeys);
    }
}