// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Linq;
using AbreVinci.Amazon.DynamoDB.Core.Expressions;
using AbreVinci.Amazon.DynamoDB.Model;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core.Expressions
{
    internal static class DynamoDBProjectionExpressionExtensions
    {
        public static string Compile(this IEnumerable<DynamoDBAttributePath> projection, IDynamoDBAttributeIdentifierGenerator attributeIdentifierGenerator)
        {
            var builder = new DynamoDBExpressionBuilder();
            foreach (var attribute in projection)
            {
                if (builder.Tokens.Any())
                    builder.AddToken(DynamoDBExpressionToken.Comma);
                builder.AddToken(DynamoDBExpressionToken.Attribute(attribute));
            }

            return DynamoDBExpressionCompiler.Compile(builder, attributeIdentifierGenerator);
        }
    }
}