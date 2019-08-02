// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Core.Expressions
{
    [PublicAPI]
    public interface IDynamoDBAttributeIdentifierGenerator
    {
        /// <summary>
        /// The current dictionary of attribute names by identifier to be used in the dynamoDB request.
        /// </summary>
        Dictionary<string, string> ExpressionAttributeNames { get; }

        /// <summary>
        /// This should generate a valid identifier for use as a replacement for the given attribute name in expressions.
        /// </summary>
        /// <remarks>
        /// Note that not all attribute names need this, some may be used as they are, but others need to be replaced due
        /// to lexical reasons or due to the fact that they are dynamoDB keywords.
        /// </remarks>
        /// <param name="attributeName">The attribute name for which to generate an identifier.</param>
        /// <returns></returns>
        string GenerateAttributeIdentifier(string attributeName);
    }
}