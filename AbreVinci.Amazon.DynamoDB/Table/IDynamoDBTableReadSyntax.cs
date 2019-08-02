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
        IDynamoDBTableReadSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        IDynamoDBTableReadSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes);
        
        Task<DynamoDBMap> GetAsync(DynamoDBKeyValue hashKey);
        Task<DynamoDBMap> GetAsync(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey);

        IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue hashKey);
        IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue hashKey, DynamoDBKeyConditionExpression keyConditionExpression);

        IDynamoDBTableScanSyntax Scan();

        IDynamoDBTableBatchReadSyntax BatchRead();
    }
}