// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.BatchRead
{
    [PublicAPI]
    public interface IDynamoDBBatchReadSyntax
    {
        IDynamoDBBatchReadSyntax IncludeAttributes(IDynamoDBTable table, params DynamoDBAttributePath[] attributes);
        IDynamoDBBatchReadSyntax IncludeAttributes(IDynamoDBTable table, IEnumerable<DynamoDBAttributePath> attributes);
        
        IDynamoDBBatchReadTerminationSyntax Get(IDynamoDBTable table, DynamoDBKeyValue partitionKey);
        IDynamoDBBatchReadTerminationSyntax Get(IDynamoDBTable table, DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey);
        IDynamoDBBatchReadTerminationSyntax Get(IDynamoDBTable table, params DynamoDBKeyValue[] partitionKeys);
        IDynamoDBBatchReadTerminationSyntax Get(IDynamoDBTable table, IEnumerable<DynamoDBKeyValue> partitionKeys);
        IDynamoDBBatchReadTerminationSyntax Get(IDynamoDBTable table, params (DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)[] compositeKeys);
        IDynamoDBBatchReadTerminationSyntax Get(IDynamoDBTable table, IEnumerable<(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)> compositeKeys);
    }
}