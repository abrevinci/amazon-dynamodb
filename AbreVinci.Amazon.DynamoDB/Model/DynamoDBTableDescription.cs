// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBTableDescription
    {
        public DynamoDBTableDescription(string name, DynamoDBAttributePath partitionKeyAttribute, params DynamoDBIndexDescription[] indexDescriptions)
            : this(name, partitionKeyAttribute, null, indexDescriptions)
        {
        }

        public DynamoDBTableDescription(string name, DynamoDBAttributePath partitionKeyAttribute, DynamoDBAttributePath sortKeyAttribute, params DynamoDBIndexDescription[] indexDescriptions)
        {
            Name = name;
            PartitionKeyAttribute = partitionKeyAttribute;
            SortKeyAttribute = sortKeyAttribute;
            Indexes = indexDescriptions;
        }

        public string Name { get; }
        public DynamoDBAttributePath PartitionKeyAttribute { get; }
        public DynamoDBAttributePath SortKeyAttribute { get; }
        public IEnumerable<DynamoDBIndexDescription> Indexes { get; }
    }
}