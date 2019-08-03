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

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Table.DynamoDBTableTests.PutAsync
{
    public class WithoutReturnOldItem
    {
        private readonly Mock<IDynamoDBClient> _client;
        private readonly IDynamoDBTable _table;

        public WithoutReturnOldItem()
        {
            _client = new Mock<IDynamoDBClient>();
            var tableDescription = new DynamoDBTableDescription("MyTable", "id");
            _table = new DynamoDB.Default.Internal.Table.DynamoDBTable(_client.Object, tableDescription);
        }

        [Fact]
        public async Task ShouldReturnNull()
        {
            // Arrange
            _client
                .Setup(c => c.PutAsync(It.IsAny<DynamoDBTablePutRequest>()))
                .ReturnsAsync((DynamoDBMap)null);

            // Act
            var result = await _table.PutAsync(new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"});

            // Assert
            result.Should().BeNull();
        }
        
        [Fact]
        public async Task ShouldSetTableAndItem()
        {
            // Arrange
            DynamoDBTablePutRequest request = null;
            _client
                .Setup(c => c.PutAsync(It.IsAny<DynamoDBTablePutRequest>()))
                .Callback<DynamoDBTablePutRequest>(r => request = r)
                .ReturnsAsync((DynamoDBMap)null);

            // Act
            await _table.PutAsync(new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"});

            // Assert
            request.Should().NotBeNull();
            request.TableName.Should().Be("MyTable");
            request.Item.Should().BeEquivalentTo(
                new DynamoDBMap
                {
                    ["id"] = 1, 
                    ["value1"] = 3, 
                    ["value2"] = "hello"
                });
            request.ReturnOldItem.Should().BeFalse();
        }
    }
}