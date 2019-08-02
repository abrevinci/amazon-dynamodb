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

            var item = content.Items.FirstOrDefault(i => MatchesKey(i, request.HashKeyAttribute, request.HashKey, request.RangeKeyAttribute, request.RangeKey));

            if (item == null && request.UseConsistentRead)
                item = content.ConsistentReadOnlyItems.FirstOrDefault(i => MatchesKey(i, request.HashKeyAttribute, request.HashKey, request.RangeKeyAttribute, request.RangeKey));

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

        #endregion

        #region Private

        public bool MatchesKey(
            DynamoDBMap item,
            DynamoDBAttributePath hashKeyAttribute,
            DynamoDBKeyValue hashKey,
            DynamoDBAttributePath rangeKeyAttribute,
            DynamoDBKeyValue rangeKey)
        {
            if (!item.TryGetValue(hashKeyAttribute.ToString(), out var h) || (DynamoDBKeyValue)h != hashKey)
                return false;

            if (rangeKeyAttribute != null && rangeKey != null)
            {
                if (!item.TryGetValue(rangeKeyAttribute.ToString(), out var r) || (DynamoDBKeyValue)r != rangeKey)
                    return false;
            }

            return true;
        }

        #endregion
    }
}