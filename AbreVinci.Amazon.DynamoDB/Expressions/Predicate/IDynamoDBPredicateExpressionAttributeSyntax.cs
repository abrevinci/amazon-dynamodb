// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.Predicate
{
    [PublicAPI]
    public interface IDynamoDBPredicateExpressionAttributeSyntax
    {
        IDynamoDBPredicateExpressionNonEmptySyntax Exists();
        IDynamoDBPredicateExpressionNonEmptySyntax DoesNotExist();
        IDynamoDBPredicateExpressionNonEmptySyntax IsOfType<T>() where T : DynamoDBValue;
        IDynamoDBPredicateExpressionNonEmptySyntax Equals(DynamoDBPrimitive value);
        IDynamoDBPredicateExpressionNonEmptySyntax DoesNotEqual(DynamoDBPrimitive value);
        IDynamoDBPredicateExpressionNonEmptySyntax IsGreaterThan(DynamoDBPrimitive value);
        IDynamoDBPredicateExpressionNonEmptySyntax IsGreaterThanOrEquals(DynamoDBPrimitive value);
        IDynamoDBPredicateExpressionNonEmptySyntax IsLessThan(DynamoDBPrimitive value);
        IDynamoDBPredicateExpressionNonEmptySyntax IsLessThanOrEquals(DynamoDBPrimitive value);
        IDynamoDBPredicateExpressionNonEmptySyntax IsBetween(DynamoDBPrimitive value1, DynamoDBPrimitive value2);
        IDynamoDBPredicateExpressionNonEmptySyntax BeginsWith(string value);
        IDynamoDBPredicateExpressionNonEmptySyntax IsIn(IEnumerable<DynamoDBPrimitive> values);
        IDynamoDBPredicateExpressionNonEmptySyntax Contains(DynamoDBPrimitive value);
        IDynamoDBPredicateExpressionNonEmptySyntax SizeEquals(int size);
        IDynamoDBPredicateExpressionNonEmptySyntax SizeDoesNotEqual(int size);
        IDynamoDBPredicateExpressionNonEmptySyntax SizeIsGreaterThan(int size);
        IDynamoDBPredicateExpressionNonEmptySyntax SizeIsGreaterThanOrEquals(int size);
        IDynamoDBPredicateExpressionNonEmptySyntax SizeIsLessThan(int size);
        IDynamoDBPredicateExpressionNonEmptySyntax SizeIsLessThanOrEquals(int size);

        IDynamoDBPredicateExpressionAttributeSyntax Attr(DynamoDBAttributePath childAttribute);
    }
}