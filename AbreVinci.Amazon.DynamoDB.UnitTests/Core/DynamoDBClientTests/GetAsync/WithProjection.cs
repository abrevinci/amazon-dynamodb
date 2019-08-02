// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Default.Internal.Core;
using AbreVinci.Amazon.DynamoDB.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using FluentAssertions;
using Moq;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.DynamoDBClientTests.GetAsync
{
    public class WithProjection
    {
        private readonly Mock<IAmazonDynamoDB> _awsClient;
        private readonly IDynamoDBClient _client;

        public WithProjection()
        {
            _awsClient = new Mock<IAmazonDynamoDB>();
            _client = new DynamoDBClient(_awsClient.Object, null);
        }

        [Fact]
        public async Task ShouldSetProjectionExpression()
        {
            // Arrange
            GetItemRequest awsRequest = null;
            _awsClient
                .Setup(c => c.GetItemAsync(It.IsAny<GetItemRequest>(), It.IsAny<CancellationToken>()))
                .Callback<GetItemRequest, CancellationToken>((r, _) => awsRequest = r)
                .ReturnsAsync(new GetItemResponse());
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, false, new DynamoDBAttributePath[] {"id", "value1"});

            // Act
            await _client.GetAsync(request);

            // Assert
            awsRequest.Should().NotBeNull();
            awsRequest.ProjectionExpression.Should().Be("#a0, #a1");
            awsRequest.ExpressionAttributeNames.Should().BeEquivalentTo(new Dictionary<string, string>
            {
                ["#a0"] = "id",
                ["#a1"] = "value1"
            });
        }
    }
}