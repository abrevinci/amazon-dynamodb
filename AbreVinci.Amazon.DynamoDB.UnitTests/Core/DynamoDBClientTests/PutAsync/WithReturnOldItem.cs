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
using Moq;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.DynamoDBClientTests.PutAsync
{
    public class WithReturnOldItem
    {
        private readonly Mock<IAmazonDynamoDB> _awsClient;
        private readonly IDynamoDBClient _client;

        public WithReturnOldItem()
        {
            _awsClient = new Mock<IAmazonDynamoDB>();
            _client = new DynamoDBClient(_awsClient.Object, null);
        }
        
        [Fact]
        public async Task ShouldReturnNullWhenOldItemDoesNotExist()
        {
            // Arrange
            _awsClient
                .Setup(c => c.PutItemAsync(It.IsAny<PutItemRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PutItemResponse());
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, true);
            
            // Act
            var result = await _client.PutAsync(request);
            
            // Assert
            result.Should().BeNull();
        }
        
        [Fact]
        public async Task ShouldReturnOldItemWhenItExists()
        {
            // Arrange
            _awsClient
                .Setup(c => c.PutItemAsync(It.IsAny<PutItemRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                    new PutItemResponse
                    {
                        Attributes = new Dictionary<string, AttributeValue>
                        {
                            ["id"] = new AttributeValue {N = "1"},
                            ["value1"] = new AttributeValue {N = "2"},
                            ["value2"] = new AttributeValue {S = "hi"}
                        }
                    });
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, true);
            
            // Act
            var result = await _client.PutAsync(request);
            
            // Assert
            result.Should().BeEquivalentTo(
                new DynamoDBMap
                {
                    ["id"] = 1,
                    ["value1"] = 2,
                    ["value2"] = "hi"
                });
        }
        
        [Fact]
        public async Task ShouldSetReturnValuesToAllOld()
        {
            // Arrange
            PutItemRequest awsRequest = null;
            _awsClient
                .Setup(c => c.PutItemAsync(It.IsAny<PutItemRequest>(), It.IsAny<CancellationToken>()))
                .Callback<PutItemRequest, CancellationToken>((r, _) => awsRequest = r)
                .ReturnsAsync(new PutItemResponse());
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, true);
            
            // Act
            await _client.PutAsync(request);
            
            // Assert
            awsRequest.Should().NotBeNull();
            awsRequest.ReturnValues.Should().Be(ReturnValue.ALL_OLD);
        }
    }
}