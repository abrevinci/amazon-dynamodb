// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core.Expressions
{
    internal abstract class DynamoDBExpressionToken
    {
        #region Tokens

        public static readonly DynamoDBExpressionToken Comma = new SimpleToken(", ");

        public static DynamoDBExpressionToken Attribute(DynamoDBAttributePath attribute) => new AttributeToken(attribute);

        #endregion

        #region Token Types

        public sealed class SimpleToken : DynamoDBExpressionToken
        {
            public SimpleToken(string token)
            {
                Token = token;
            }

            public string Token { get; }
        }

        public sealed class AttributeToken : DynamoDBExpressionToken
        {
            public AttributeToken(DynamoDBAttributePath attribute)
            {
                AttributePath = attribute.Path;
            }

            public IReadOnlyList<string> AttributePath { get; }
        }

        #endregion

        #region Private

        private DynamoDBExpressionToken()
        {
        }

        #endregion
    }
}