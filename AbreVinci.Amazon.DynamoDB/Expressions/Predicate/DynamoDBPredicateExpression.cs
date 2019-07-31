// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.Predicate
{
    [PublicAPI]
    public delegate IDynamoDBPredicateExpressionTerminationSyntax DynamoDBPredicateExpression(IDynamoDBPredicateExpressionSyntax expression);
}