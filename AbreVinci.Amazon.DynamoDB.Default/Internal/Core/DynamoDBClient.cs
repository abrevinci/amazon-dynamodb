// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Default.Internal.Core.Expressions;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core
{
    internal class DynamoDBClient : IDynamoDBClient
    {
        #region Fields

        private readonly IAmazonDynamoDB _awsClient;
        private readonly DynamoDBClientConfig _config;

        #endregion

        #region Constructor

        public DynamoDBClient(IAmazonDynamoDB awsClient, DynamoDBClientConfig config)
        {
            _awsClient = awsClient;
            _config = config;
        }

        #endregion

        #region IDynamoDBClient

        public async Task<DynamoDBMap> GetAsync(DynamoDBTableGetRequest request)
        {
            var attributeIdentifierGenerator = _config?.CreateAttributeIdentifierGenerator?.Invoke() ?? new DynamoDBReplaceAllAttributeIdentifierGenerator();

            var awsRequest = new GetItemRequest
            {
                TableName = request.TableName,
                ConsistentRead = request.UseConsistentRead,
                Key = MakeAwsKey(request.PartitionKeyAttribute, request.PartitionKey, request.SortKeyAttribute, request.SortKey),
            };

            if (request.ProjectedAttributes != null && request.ProjectedAttributes.Any())
                awsRequest.ProjectionExpression = request.ProjectedAttributes.Compile(attributeIdentifierGenerator);

            if (attributeIdentifierGenerator.ExpressionAttributeNames.Any())
                awsRequest.ExpressionAttributeNames = attributeIdentifierGenerator.ExpressionAttributeNames;

            var response = await _awsClient.GetItemAsync(awsRequest);

            return response.IsItemSet ? response.Item.ToMap() : null;
        }

        public async Task<DynamoDBMap> PutAsync(DynamoDBTablePutRequest request)
        {
            var awsRequest = new PutItemRequest
            {
                TableName = request.TableName,
                Item = request.Item.ToAwsDictionary(),
                ReturnValues = request.ReturnOldItem ? ReturnValue.ALL_OLD : ReturnValue.NONE
            };

            var response = await _awsClient.PutItemAsync(awsRequest);

            return request.ReturnOldItem && response.Attributes != null && response.Attributes.Any() ? response.Attributes.ToMap() : null;
        }

        #endregion

        #region Private

        private static Dictionary<string, AttributeValue> MakeAwsKey(
            DynamoDBAttributePath partitionKeyAttribute,
            DynamoDBKeyValue partitionKey,
            DynamoDBAttributePath sortKeyAttribute,
            DynamoDBKeyValue sortKey)
        {
            var key = new Dictionary<string, AttributeValue>
            {
                [partitionKeyAttribute.ToString()] = partitionKey.ToAwsValue()
            };

            if (sortKeyAttribute != null && sortKey != null)
                key[sortKeyAttribute.ToString()] = sortKey.ToAwsValue();

            return key;
        }

        #endregion
    }
}