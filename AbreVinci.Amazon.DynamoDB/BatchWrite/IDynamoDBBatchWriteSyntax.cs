// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.BatchWrite
{
    [PublicAPI]
    public interface IDynamoDBBatchWriteSyntax
    {
        IDynamoDBBatchWriteTerminationSyntax Put(IDynamoDBTable table, DynamoDBMap item);
        IDynamoDBBatchWriteTerminationSyntax Put(IDynamoDBTable table, params DynamoDBMap[] items);
        IDynamoDBBatchWriteTerminationSyntax Put(IDynamoDBTable table, IEnumerable<DynamoDBMap> items);
        
        IDynamoDBBatchWriteTerminationSyntax Delete(IDynamoDBTable table, DynamoDBKeyValue partitionKey);
        IDynamoDBBatchWriteTerminationSyntax Delete(IDynamoDBTable table, DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey);
        IDynamoDBBatchWriteTerminationSyntax Delete(IDynamoDBTable table, params DynamoDBKeyValue[] partitionKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(IDynamoDBTable table, IEnumerable<DynamoDBKeyValue> partitionKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(IDynamoDBTable table, params (DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)[] compositeKeys);
        IDynamoDBBatchWriteTerminationSyntax Delete(IDynamoDBTable table, IEnumerable<(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)> compositeKeys);
    }
}