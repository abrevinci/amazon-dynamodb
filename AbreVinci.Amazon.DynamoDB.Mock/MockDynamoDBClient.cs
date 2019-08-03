// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Mock
{
    [PublicAPI]
    public class MockDynamoDBClient : IDynamoDBClient
    {
        #region Mocking

        public Dictionary<string, MockDynamoDBTableContent> Tables { get; set; } = new Dictionary<string, MockDynamoDBTableContent>();

        #endregion

        #region IDynamoDBClient

        public Task<DynamoDBMap> GetAsync(DynamoDBTableGetRequest request)
        {
            if (!Tables.TryGetValue(request.TableName, out var content))
                throw new Exception("Table not found");

            var item = content.Items.FirstOrDefault(i => MatchesKey(i, request.PartitionKeyAttribute, request.PartitionKey, request.SortKeyAttribute, request.SortKey));

            if (item == null && request.UseConsistentRead)
                item = content.ConsistentReadOnlyItems.FirstOrDefault(i => MatchesKey(i, request.PartitionKeyAttribute, request.PartitionKey, request.SortKeyAttribute, request.SortKey));

            if (item != null && request.ProjectedAttributes != null && request.ProjectedAttributes.Any())
            {
                var projectedItem = new DynamoDBMap();
                foreach (var projectedAttribute in request.ProjectedAttributes)
                {
                    if (projectedAttribute.Path.Count != 1)
                        throw new NotImplementedException("Attribute paths with length other than one are not yet implemented.");

                    if (item.TryGetValue(projectedAttribute.Path[0], out var value))
                        projectedItem.Add(projectedAttribute.Path[0], value);
                }

                item = projectedItem;
            }

            return Task.FromResult(item);
        }

        public Task<DynamoDBMap> PutAsync(DynamoDBTablePutRequest request)
        {
            if (!Tables.TryGetValue(request.TableName, out var content))
                throw new Exception("Table not found");
            
            if (!request.Item.TryGetValue(content.PartitionKeyAttribute.ToString(), out var partitionKey))
                throw new Exception("Partition key not set.");

            DynamoDBValue sortKey = null;
            if (content.SortKeyAttribute != null && !request.Item.TryGetValue(content.SortKeyAttribute.ToString(), out sortKey))
                throw new Exception("Sort key not set.");
            
            var item = content.Items.FirstOrDefault(i => MatchesKey(i, content.PartitionKeyAttribute, (DynamoDBKeyValue)partitionKey, content.SortKeyAttribute, (DynamoDBKeyValue)sortKey));

            content.Items.Remove(item);
            content.Items.Add(request.Item);
            
            return Task.FromResult(request.ReturnOldItem ? item : null);
        }

        #endregion

        #region Private

        public bool MatchesKey(
            DynamoDBMap item,
            DynamoDBAttributePath partitionKeyAttribute,
            DynamoDBKeyValue partitionKey,
            DynamoDBAttributePath sortKeyAttribute,
            DynamoDBKeyValue sortKey)
        {
            if (!item.TryGetValue(partitionKeyAttribute.ToString(), out var h) || (DynamoDBKeyValue)h != partitionKey)
                return false;

            if (sortKeyAttribute != null && sortKey != null)
            {
                if (!item.TryGetValue(sortKeyAttribute.ToString(), out var r) || (DynamoDBKeyValue)r != sortKey)
                    return false;
            }

            return true;
        }

        #endregion
    }
}