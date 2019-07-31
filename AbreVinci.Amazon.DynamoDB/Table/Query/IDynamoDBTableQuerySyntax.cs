// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Expressions.Predicate;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Query
{
    [PublicAPI]
    public interface IDynamoDBTableQuerySyntax : IDynamoDBTableQueryTerminationSyntax
    {
        IDynamoDBTableQuerySyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        
        IDynamoDBTableQueryFilteredSyntax Filter(DynamoDBPredicateExpression predicateExpression);
    }
}