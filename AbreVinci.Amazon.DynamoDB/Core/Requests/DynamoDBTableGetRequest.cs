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
            DynamoDBAttributePath hashKeyAttribute,
            DynamoDBKeyValue hashKey,
            bool useConsistentRead,
            IEnumerable<DynamoDBAttributePath> projectedAttributes)
        {
            TableName = tableName;
            HashKeyAttribute = hashKeyAttribute;
            HashKey = hashKey;
            RangeKeyAttribute = null;
            RangeKey = null;
            UseConsistentRead = useConsistentRead;
            ProjectedAttributes = projectedAttributes?.ToList();
        }

        public DynamoDBTableGetRequest(
            string tableName,
            DynamoDBAttributePath hashKeyAttribute,
            DynamoDBKeyValue hashKey,
            DynamoDBAttributePath rangeKeyAttribute,
            DynamoDBKeyValue rangeKey,
            bool useConsistentRead,
            IEnumerable<DynamoDBAttributePath> projectedAttributes)
        {
            TableName = tableName;
            HashKeyAttribute = hashKeyAttribute;
            HashKey = hashKey;
            RangeKeyAttribute = rangeKeyAttribute;
            RangeKey = rangeKey;
            UseConsistentRead = useConsistentRead;
            ProjectedAttributes = projectedAttributes?.ToList();
        }

        public string TableName { get; }
        public DynamoDBAttributePath HashKeyAttribute { get; }
        public DynamoDBKeyValue HashKey { get; }
        public DynamoDBAttributePath RangeKeyAttribute { get; }
        public DynamoDBKeyValue RangeKey { get; }
        public bool UseConsistentRead { get; }
        public IReadOnlyList<DynamoDBAttributePath> ProjectedAttributes { get; }
    }
}