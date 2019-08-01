// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBIndexDescription
    {
        public DynamoDBIndexDescription(string name, DynamoDBAttributePath hashKeyAttribute, DynamoDBAttributePath rangeKeyAttribute = null)
        {
            Name = name;
            HashKeyAttribute = hashKeyAttribute;
            RangeKeyAttribute = rangeKeyAttribute;
        }
        
        public string Name { get; }
        public bool IsLocal { get; }
        public DynamoDBAttributePath HashKeyAttribute { get; }
        public DynamoDBAttributePath RangeKeyAttribute { get; }
    }
}