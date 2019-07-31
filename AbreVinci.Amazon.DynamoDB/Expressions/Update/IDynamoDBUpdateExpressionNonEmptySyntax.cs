// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.Update
{
    [PublicAPI]
    public interface IDynamoDBUpdateExpressionNonEmptySyntax : IDynamoDBUpdateExpressionSyntax, IDynamoDBUpdateExpressionTerminationSyntax
    {
    }
}