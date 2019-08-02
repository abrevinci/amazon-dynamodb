// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Expressions.Predicate;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Index.Query
{
    [PublicAPI]
    public interface IDynamoDBIndexQuerySyntax : IDynamoDBIndexQueryTerminationSyntax
    {
        IDynamoDBIndexQuerySyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        IDynamoDBIndexQuerySyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes);

        IDynamoDBIndexQueryFilteredSyntax Filter(DynamoDBPredicateExpression predicateExpression);
    }
}