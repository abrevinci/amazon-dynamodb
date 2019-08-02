// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Model;
using FluentAssertions;
using Moq;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.DynamoDBTests
{
    public class AccessTable
    {
        private readonly IDynamoDB _dynamoDB;

        public AccessTable()
        {
            var client = new Mock<IDynamoDBClient>();
            _dynamoDB = new DynamoDB.Default.Internal.DynamoDB(client.Object);
        }

        [Fact]
        public void ShouldReturnTableInterfaceWithCorrectAttributes()
        {
            // Arrange
            var tableDescription = new DynamoDBTableDescription("MyTable", "id");

            // Act
            var table = _dynamoDB.AccessTable(tableDescription);

            // Assert
            table.Name.Should().Be("MyTable");
            table.HashKeyAttribute.ToString().Should().Be("id");
            table.RangeKeyAttribute.Should().BeNull();
            table.Indexes.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnTableInterfaceWithCorrectAttributesAndIndexes()
        {
            // Arrange
            var index1Description = new DynamoDBIndexDescription("Index1", "key3");
            var index2Description = new DynamoDBIndexDescription("Index2", "key2", "key3");
            var tableDescription = new DynamoDBTableDescription("MyTable", "key1", "key2", index1Description, index2Description);

            // Act
            var table = _dynamoDB.AccessTable(tableDescription);

            // Assert
            table.Name.Should().Be("MyTable");
            table.HashKeyAttribute.ToString().Should().Be("key1");
            table.RangeKeyAttribute.ToString().Should().Be("key2");
            table.Indexes.Should().HaveCount(2);
            table.Indexes.TryGetValue("Index1", out var index1).Should().BeTrue();
            table.Indexes.TryGetValue("Index2", out var index2).Should().BeTrue();
            index1.Name.Should().Be("Index1");
            index1.HashKeyAttribute.ToString().Should().Be("key3");
            index1.RangeKeyAttribute.Should().BeNull();
            index2.Name.Should().Be("Index2");
            index2.HashKeyAttribute.ToString().Should().Be("key2");
            index2.RangeKeyAttribute.ToString().Should().Be("key3");
        }
    }
}