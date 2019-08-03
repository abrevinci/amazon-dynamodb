// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition
{
    [PublicAPI]
    public interface IDynamoDBKeyConditionExpressionSyntax
    {
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyEquals(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyDoesNotEqual(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyIsGreaterThan(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyIsGreaterThanOrEquals(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyIsLessThan(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyIsLessThanOrEquals(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyIsBetween(DynamoDBKeyValue value1, DynamoDBKeyValue value2);
        IDynamoDBKeyConditionExpressionTerminationSyntax SortKeyBeginsWith(string value);
    }
}