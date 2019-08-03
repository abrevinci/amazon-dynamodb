// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table.Index.Query;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Index
{
    [PublicAPI]
    public interface IDynamoDBIndexReadSyntax
    {
        IDynamoDBIndexReadSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        IDynamoDBIndexReadSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes);

        IDynamoDBIndexQuerySyntax Query(DynamoDBKeyValue partitionKey);
        IDynamoDBIndexQuerySyntax Query(DynamoDBKeyValue partitionKey, DynamoDBKeyConditionExpression keyConditionExpression);
    }
}