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

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Table.DynamoDBTableTests.GetAsync
{
    public class WithCompositeKey
    {
        private readonly Mock<IDynamoDBClient> _client;
        private readonly IDynamoDBTable _table;

        public WithCompositeKey()
        {
            _client = new Mock<IDynamoDBClient>();
            var tableDescription = new DynamoDBTableDescription("MyTable", "id", "sort");
            _table = new DynamoDB.Default.Internal.Table.DynamoDBTable(_client.Object, tableDescription);
        }

        [Fact]
        public async Task ShouldReturnNullWhenItemDoesNotExist()
        {
            // Arrange
            _client
                .Setup(c => c.GetAsync(It.IsAny<DynamoDBTableGetRequest>()))
                .ReturnsAsync((DynamoDBMap)null);

            // Act
            var result = await _table.GetAsync(1, 2);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ShouldReturnItemWhenItExists()
        {
            // Arrange
            var item = new DynamoDBMap
            {
                ["id"] = 1,
                ["sort"] = 2,
                ["value"] = "hello"
            };
            _client
                .Setup(c => c.GetAsync(It.IsAny<DynamoDBTableGetRequest>()))
                .ReturnsAsync(item);

            // Act
            var result = await _table.GetAsync(1, 2);

            // Assert
            result.Should().BeEquivalentTo(item);
        }

        [Fact]
        public async Task ShouldSetTableAndKey()
        {
            // Arrange
            DynamoDBTableGetRequest request = null;
            _client
                .Setup(c => c.GetAsync(It.IsAny<DynamoDBTableGetRequest>()))
                .Callback<DynamoDBTableGetRequest>(r => request = r)
                .ReturnsAsync((DynamoDBMap)null);

            // Act
            await _table.GetAsync(1, 2);

            // Assert
            request.Should().NotBeNull();
            request.TableName.Should().Be("MyTable");
            request.PartitionKeyAttribute.Should().Be("id");
            request.PartitionKey.Should().Be((DynamoDBNumber)1);
            request.SortKeyAttribute.Should().Be("sort");
            request.SortKey.Should().Be((DynamoDBNumber)2);
            request.UseConsistentRead.Should().BeFalse();
            request.ProjectedAttributes.Should().BeNull();
        }
    }
}