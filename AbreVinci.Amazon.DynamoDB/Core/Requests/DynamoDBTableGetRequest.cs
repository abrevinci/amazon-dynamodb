// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Linq;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Core.Requests
{
    /// <summary>
    /// Describes a get request in terms of library abstractions and is the input to <see cref="IDynamoDBClient.GetAsync"/>.
    /// </summary>
    [PublicAPI]
    public class DynamoDBTableGetRequest
    {
        public DynamoDBTableGetRequest(
            string tableName,
            DynamoDBAttributePath partitionKeyAttribute,
            DynamoDBKeyValue partitionKey,
            bool useConsistentRead,
            IEnumerable<DynamoDBAttributePath> projectedAttributes)
        {
            TableName = tableName;
            PartitionKeyAttribute = partitionKeyAttribute;
            PartitionKey = partitionKey;
            SortKeyAttribute = null;
            SortKey = null;
            UseConsistentRead = useConsistentRead;
            ProjectedAttributes = projectedAttributes?.ToList();
        }

        public DynamoDBTableGetRequest(
            string tableName,
            DynamoDBAttributePath partitionKeyAttribute,
            DynamoDBKeyValue partitionKey,
            DynamoDBAttributePath sortKeyAttribute,
            DynamoDBKeyValue sortKey,
            bool useConsistentRead,
            IEnumerable<DynamoDBAttributePath> projectedAttributes)
        {
            TableName = tableName;
            PartitionKeyAttribute = partitionKeyAttribute;
            PartitionKey = partitionKey;
            SortKeyAttribute = sortKeyAttribute;
            SortKey = sortKey;
            UseConsistentRead = useConsistentRead;
            ProjectedAttributes = projectedAttributes?.ToList();
        }

        public string TableName { get; }
        public DynamoDBAttributePath PartitionKeyAttribute { get; }
        public DynamoDBKeyValue PartitionKey { get; }
        public DynamoDBAttributePath SortKeyAttribute { get; }
        public DynamoDBKeyValue SortKey { get; }
        public bool UseConsistentRead { get; }
        public IReadOnlyList<DynamoDBAttributePath> ProjectedAttributes { get; }
    }
}