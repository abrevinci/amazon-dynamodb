// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition
{
    [PublicAPI]
    public interface IDynamoDBKeyConditionExpressionSyntax
    {
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyEquals(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyDoesNotEqual(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyIsGreaterThan(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyIsGreaterThanOrEquals(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyIsLessThan(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyIsLessThanOrEquals(DynamoDBKeyValue value);
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyIsBetween(DynamoDBKeyValue value1, DynamoDBKeyValue value2);
        IDynamoDBKeyConditionExpressionTerminationSyntax RangeKeyBeginsWith(string value);
    }
}