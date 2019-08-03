// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Default.Internal.Core;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using FluentAssertions;
using Xunit;
using Moq;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.DynamoDBClientTests.PutAsync
{
    public class WithoutReturnOldItem
    {
        private readonly Mock<IAmazonDynamoDB> _awsClient;
        private readonly IDynamoDBClient _client;

        public WithoutReturnOldItem()
        {
            _awsClient = new Mock<IAmazonDynamoDB>();
            _client = new DynamoDBClient(_awsClient.Object, null);
        }
        
        [Fact]
        public async Task ShouldReturnNull()
        {
            // Arrange
            _awsClient
                .Setup(c => c.PutItemAsync(It.IsAny<PutItemRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PutItemResponse());
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, false);
            
            // Act
            var result = await _client.PutAsync(request);
            
            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ShouldSetTableAndItem()
        {
            // Arrange
            PutItemRequest awsRequest = null;
            _awsClient
                .Setup(c => c.PutItemAsync(It.IsAny<PutItemRequest>(), It.IsAny<CancellationToken>()))
                .Callback<PutItemRequest, CancellationToken>((r, _) => awsRequest = r)
                .ReturnsAsync(new PutItemResponse());
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, false);
            
            // Act
            await _client.PutAsync(request);
            
            // Assert
            awsRequest.Should().NotBeNull();
            awsRequest.TableName.Should().Be("MyTable");
            awsRequest.Item.Should().BeEquivalentTo(new Dictionary<string, AttributeValue>
            {
                ["id"] = new AttributeValue {N = "1"},
                ["value1"] = new AttributeValue {N = "3"},
                ["value2"] = new AttributeValue {S = "hello"}
            });
            awsRequest.ReturnValues.Should().Be(ReturnValue.NONE);
            awsRequest.ConditionExpression.Should().BeNull();
            awsRequest.ExpressionAttributeNames.Should().BeEmpty();
            awsRequest.ExpressionAttributeValues.Should().BeEmpty();
        }
    }
}