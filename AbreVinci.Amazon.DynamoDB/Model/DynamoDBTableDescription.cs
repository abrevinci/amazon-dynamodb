// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBTableDescription
    {
        public DynamoDBTableDescription(string name, DynamoDBAttributePath hashKeyAttribute, params DynamoDBIndexDescription[] indexDescriptions)
            : this(name, hashKeyAttribute, null, indexDescriptions)
        {
        }

        public DynamoDBTableDescription(string name, DynamoDBAttributePath hashKeyAttribute, DynamoDBAttributePath rangeKeyAttribute, params DynamoDBIndexDescription[] indexDescriptions)
        {
            Name = name;
            HashKeyAttribute = hashKeyAttribute;
            RangeKeyAttribute = rangeKeyAttribute;
            Indexes = indexDescriptions;
        }
        
        public string Name { get; }
        public DynamoDBAttributePath HashKeyAttribute { get; }
        public DynamoDBAttributePath RangeKeyAttribute { get; }
        public IEnumerable<DynamoDBIndexDescription> Indexes { get; }
    }
}