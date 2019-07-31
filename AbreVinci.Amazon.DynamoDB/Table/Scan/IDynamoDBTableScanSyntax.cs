// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Expressions.Predicate;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Scan
{
    [PublicAPI]
    public interface IDynamoDBTableScanSyntax : IDynamoDBTableScanTerminationSyntax
    {
        IDynamoDBTableScanSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        
        IDynamoDBTableScanFilteredSyntax Filter(DynamoDBPredicateExpression predicateExpression);
    }
}