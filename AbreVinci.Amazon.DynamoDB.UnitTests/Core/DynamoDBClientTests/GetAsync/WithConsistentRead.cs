// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Default.Internal.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using FluentAssertions;
using Moq;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.DynamoDBClientTests.GetAsync
{
    public class WithConsistentRead
    {
        private readonly Mock<IAmazonDynamoDB> _awsClient;
        private readonly IDynamoDBClient _client;

        public WithConsistentRead()
        {
            _awsClient = new Mock<IAmazonDynamoDB>();
            _client = new DynamoDBClient(_awsClient.Object, null);
        }

        [Fact]
        public async Task ShouldSetConsistentRead()
        {
            // Arrange
            GetItemRequest awsRequest = null;
            _awsClient
                .Setup(c => c.GetItemAsync(It.IsAny<GetItemRequest>(), It.IsAny<CancellationToken>()))
                .Callback<GetItemRequest, CancellationToken>((r, _) => awsRequest = r)
                .ReturnsAsync(new GetItemResponse());
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, true, null);

            // Act
            await _client.GetAsync(request);

            // Assert
            awsRequest.Should().NotBeNull();
            awsRequest.ConsistentRead.Should().BeTrue();
        }
    }
}