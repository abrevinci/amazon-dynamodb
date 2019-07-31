// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table.Index.Query;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Index
{
    [PublicAPI]
    public interface IDynamoDBIndexReadSyntax
    {
        IDynamoDBIndexQuerySyntax Query(DynamoDBKeyValue hashKey);
        IDynamoDBIndexQuerySyntax Query(DynamoDBKeyValue hashKey, DynamoDBKeyConditionExpression keyConditionExpression);
    }
}