// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.BatchRead
{
    [PublicAPI]
    public interface IDynamoDBTableBatchReadSyntax
    {
        IDynamoDBTableBatchReadSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        IDynamoDBTableBatchReadSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes);

        IDynamoDBTableBatchReadTerminationSyntax Get(DynamoDBKeyValue partitionKey);
        IDynamoDBTableBatchReadTerminationSyntax Get(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey);

        IDynamoDBTableBatchReadTerminationSyntax Get(params DynamoDBKeyValue[] partitionKeys);
        IDynamoDBTableBatchReadTerminationSyntax Get(IEnumerable<DynamoDBKeyValue> partitionKeys);
        IDynamoDBTableBatchReadTerminationSyntax Get(params (DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)[] compositeKeys);
        IDynamoDBTableBatchReadTerminationSyntax Get(IEnumerable<(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)> compositeKeys);
    }
}