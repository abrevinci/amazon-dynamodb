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

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.DynamoDBClientTests.GetAsync
{
    public class WithCompositeKey
    {
        private readonly Mock<IAmazonDynamoDB> _awsClient;
        private readonly IDynamoDBClient _client;

        public WithCompositeKey()
        {
            _awsClient = new Mock<IAmazonDynamoDB>();
            _client = new DynamoDBClient(_awsClient.Object, null);
        }

        [Fact]
        public async Task ShouldReturnNullWhenItemDoesNotExist()
        {
            // Arrange
            _awsClient
                .Setup(c => c.GetItemAsync(It.IsAny<GetItemRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetItemResponse());
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, "sort", 2, false, null);

            // Act
            var result = await _client.GetAsync(request);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ShouldReturnItemWhenItExists()
        {
            // Arrange
            _awsClient
                .Setup(c => c.GetItemAsync(It.IsAny<GetItemRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                    new GetItemResponse
                    {
                        Item = new Dictionary<string, AttributeValue>
                        {
                            ["id"] = new AttributeValue {N = "1"},
                            ["sort"] = new AttributeValue {N = "2"},
                            ["value"] = new AttributeValue {S = "hello"}
                        }
                    });
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, "sort", 2, false, null);

            // Act
            var result = await _client.GetAsync(request);

            // Assert
            result.Should().BeEquivalentTo(
                new DynamoDBMap
                {
                    ["id"] = 1,
                    ["sort"] = 2,
                    ["value"] = "hello"
                });
        }

        [Fact]
        public async Task ShouldSetTableAndKey()
        {
            // Arrange
            GetItemRequest awsRequest = null;
            _awsClient
                .Setup(c => c.GetItemAsync(It.IsAny<GetItemRequest>(), It.IsAny<CancellationToken>()))
                .Callback<GetItemRequest, CancellationToken>((r, _) => awsRequest = r)
                .ReturnsAsync(new GetItemResponse());
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, "sort", 2, false, null);

            // Act
            await _client.GetAsync(request);

            // Assert
            awsRequest.Should().NotBeNull();
            awsRequest.TableName.Should().Be("MyTable");
            awsRequest.Key.Should().BeEquivalentTo(new Dictionary<string, AttributeValue>
            {
                ["id"] = new AttributeValue {N = "1"},
                ["sort"] = new AttributeValue {N = "2"}
            });
            awsRequest.ConsistentRead.Should().BeFalse();
            awsRequest.ProjectionExpression.Should().BeNull();
            awsRequest.ExpressionAttributeNames.Should().BeEmpty();
        }
    }
}