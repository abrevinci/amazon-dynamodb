// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Mock
{
    [PublicAPI]
    public class MockDynamoDBTableContent
    {
        public MockDynamoDBTableContent(DynamoDBAttributePath partitionKeyAttribute, DynamoDBAttributePath sortKeyAttribute = null)
        {
            PartitionKeyAttribute = partitionKeyAttribute;
            SortKeyAttribute = sortKeyAttribute;
        }
        
        public DynamoDBAttributePath PartitionKeyAttribute { get; }
        public DynamoDBAttributePath SortKeyAttribute { get; }
        public List<DynamoDBMap> Items { get; set; } = new List<DynamoDBMap>();
        public List<DynamoDBMap> ConsistentReadOnlyItems { get; set; } = new List<DynamoDBMap>();
    }
}