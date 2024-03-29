// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBIndexDescription
    {
        public DynamoDBIndexDescription(string name, DynamoDBAttributePath partitionKeyAttribute, DynamoDBAttributePath sortKeyAttribute = null)
        {
            Name = name;
            PartitionKeyAttribute = partitionKeyAttribute;
            SortKeyAttribute = sortKeyAttribute;
        }

        public string Name { get; }
        public bool IsLocal { get; }
        public DynamoDBAttributePath PartitionKeyAttribute { get; }
        public DynamoDBAttributePath SortKeyAttribute { get; }
    }
}