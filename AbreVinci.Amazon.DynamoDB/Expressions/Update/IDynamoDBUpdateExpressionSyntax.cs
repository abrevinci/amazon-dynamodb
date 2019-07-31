// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.Update
{
    [PublicAPI]
    public interface IDynamoDBUpdateExpressionSyntax
    {
        IDynamoDBUpdateExpressionAttributeSyntax Attr(DynamoDBAttributePath attribute);
        IDynamoDBUpdateExpressionNonEmptySyntax Remove(IEnumerable<DynamoDBAttributePath> attributes);
    }
}