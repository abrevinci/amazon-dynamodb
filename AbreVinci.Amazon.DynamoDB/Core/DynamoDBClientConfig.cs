// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using AbreVinci.Amazon.DynamoDB.Core.Expressions;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Core
{
    [PublicAPI]
    public class DynamoDBClientConfig
    {
        /// <summary>
        /// Allows overriding of the way the dynamoDB client allocates ExpressionAttributeNames for expressions.
        /// By default a very basic generator will be used that assigns identifiers a0, a1, a2 etc to all attributes,
        /// even the ones that could have worked without replacement. This makes for a faster expression generation,
        /// but may impact the size of the request sent to dynamoDB.
        /// </summary>
        public Func<IDynamoDBAttributeIdentifierGenerator> CreateAttributeIdentifierGenerator { get; set; }
    }
}