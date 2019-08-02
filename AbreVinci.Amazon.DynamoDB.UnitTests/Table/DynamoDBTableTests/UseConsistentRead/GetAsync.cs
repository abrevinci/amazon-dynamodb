// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table;
using FluentAssertions;
using Moq;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Table.DynamoDBTableTests.UseConsistentRead
{
    public class GetAsync
    {
        private readonly Mock<IDynamoDBClient> _client;
        private readonly IDynamoDBTable _table;

        public GetAsync()
        {
            _client = new Mock<IDynamoDBClient>();
            var tableDescription = new DynamoDBTableDescription("MyTable", "id", "sort");
            _table = new DynamoDB.Default.Internal.Table.DynamoDBTable(_client.Object, tableDescription);
        }

        [Fact]
        public async Task ShouldSetUseConsistentRead()
        {
            // Arrange
            DynamoDBTableGetRequest request = null;
            _client
                .Setup(c => c.GetAsync(It.IsAny<DynamoDBTableGetRequest>()))
                .Callback<DynamoDBTableGetRequest>(r => request = r)
                .ReturnsAsync((DynamoDBMap)null);

            // Act
            await _table.UseConsistentRead().GetAsync(1);

            // Assert
            request.Should().NotBeNull();
            request.UseConsistentRead.Should().BeTrue();
        }
    }
}