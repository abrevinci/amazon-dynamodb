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
        
        IDynamoDBTableBatchReadTerminationSyntax Get(DynamoDBKeyValue hashKey);
        IDynamoDBTableBatchReadTerminationSyntax Get(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey);

        IDynamoDBTableBatchReadTerminationSyntax Get(params DynamoDBKeyValue[] hashKeys);
        IDynamoDBTableBatchReadTerminationSyntax Get(IEnumerable<DynamoDBKeyValue> hashKeys);
        IDynamoDBTableBatchReadTerminationSyntax Get(params (DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey)[] compositeKeys);
        IDynamoDBTableBatchReadTerminationSyntax Get(IEnumerable<(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey)> compositeKeys);
    }
}