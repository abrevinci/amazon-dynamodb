// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbreVinci.Amazon.DynamoDB.Core.Expressions;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core.Expressions
{
    internal static class DynamoDBExpressionCompiler
    {
        public static string Compile(IDynamoDBExpressionBuilder builder, IDynamoDBAttributeIdentifierGenerator attributeIdentifierGenerator)
        {
            var expression = new StringBuilder(128);
            foreach (var token in builder.Tokens)
            {
                switch (token)
                {
                    case DynamoDBExpressionToken.AttributeToken a:
                        var path = a.AttributePath.Select(attributeIdentifierGenerator.GenerateAttributeIdentifier);
                        expression.Append(string.Join(".", path));
                        break;
                    case DynamoDBExpressionToken.SimpleToken s:
                        expression.Append(s.Token);
                        break;
                }
            }

            return expression.ToString();
        }
    }
}