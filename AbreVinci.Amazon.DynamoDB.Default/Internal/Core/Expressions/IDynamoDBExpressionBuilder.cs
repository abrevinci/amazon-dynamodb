// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core.Expressions
{
    internal interface IDynamoDBExpressionBuilder
    {
        IEnumerable<DynamoDBExpressionToken> Tokens { get; }
        void AddToken(DynamoDBExpressionToken token);
        void AddTokens(params DynamoDBExpressionToken[] tokens);
        void AddTokens(IEnumerable<DynamoDBExpressionToken> tokens);
    }
}