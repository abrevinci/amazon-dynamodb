// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.Predicate
{
    [PublicAPI]
    public interface IDynamoDBPredicateExpressionSyntax
    {
        IDynamoDBPredicateExpressionAttributeSyntax Attr(DynamoDBAttributePath attribute);
        IDynamoDBPredicateExpressionNegatedSyntax Not { get; }
    }
}