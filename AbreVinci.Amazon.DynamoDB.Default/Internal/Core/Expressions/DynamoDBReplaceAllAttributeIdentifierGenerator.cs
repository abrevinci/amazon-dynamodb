// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Linq;
using AbreVinci.Amazon.DynamoDB.Core.Expressions;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core.Expressions
{
    internal class DynamoDBReplaceAllAttributeIdentifierGenerator : IDynamoDBAttributeIdentifierGenerator
    {
        #region Constructor

        public DynamoDBReplaceAllAttributeIdentifierGenerator()
        {
            ExpressionAttributeNames = new Dictionary<string, string>();
        }

        #endregion

        #region IDynamoDBAttributeIdentifierGenerator

        public Dictionary<string, string> ExpressionAttributeNames { get; }

        public string GenerateAttributeIdentifier(string attributeName)
        {
            var existingIdentifier = ExpressionAttributeNames.FirstOrDefault(kvp => kvp.Value == attributeName).Key;
            if (existingIdentifier != null)
                return existingIdentifier;

            var identifier = $"#a{ExpressionAttributeNames.Count}";
            ExpressionAttributeNames.Add(identifier, attributeName);
            return identifier;
        }

        #endregion
    }
}