// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core.Expressions
{
    internal class DynamoDBExpressionBuilder : IDynamoDBExpressionBuilder
    {
        #region Fields

        private readonly List<DynamoDBExpressionToken> _tokens;

        #endregion

        #region Constructor

        public DynamoDBExpressionBuilder()
        {
            _tokens = new List<DynamoDBExpressionToken>();
        }

        #endregion

        #region IDynamoDBExpressionBuilder

        public IEnumerable<DynamoDBExpressionToken> Tokens => _tokens;

        public void AddToken(DynamoDBExpressionToken token)
        {
            _tokens.Add(token);
        }

        public void AddTokens(params DynamoDBExpressionToken[] tokens)
        {
            _tokens.AddRange(tokens);
        }

        public void AddTokens(IEnumerable<DynamoDBExpressionToken> tokens)
        {
            _tokens.AddRange(tokens);
        }

        #endregion
    }
}