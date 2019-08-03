// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Mock;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.MockDynamoDBClientTests.PutAsync
{
    public class WithoutReturnOldItem
    {
        [Fact]
        public void ShouldThrowWhenTableDoesNotExist()
        {
            // Arrange
            var client = new MockDynamoDBClient();
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, false);

            // Act
            Func<Task> f = async () => { await client.PutAsync(request); };

            // Assert
            f.Should().Throw<Exception>();
        }

        [Fact]
        public void ShouldThrowWhenHashKeyDoesNotExistInItem()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                }
            };
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["error"] = 1, ["value1"] = 3, ["value2"] = "hello"}, false);
            
            // Act
            Func<Task> f = async () => { await client.PutAsync(request); };

            // Assert
            f.Should().Throw<Exception>();
        }
        
        [Fact]
        public void ShouldThrowWhenRangeKeyDoesNotExistInItem()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id", "sort")
                }
            };
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, false);
            
            // Act
            Func<Task> f = async () => { await client.PutAsync(request); };

            // Assert
            f.Should().Throw<Exception>();
        }
        
        [Fact]
        public async Task ShouldReturnNull()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                }
            };
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, false);

            // Act
            var result = await client.PutAsync(request);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ShouldSaveItemToTable()
        {
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                }
            };
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, false);

            // Act
            await client.PutAsync(request);

            // Assert
            client.Tables["MyTable"].Items.Should().HaveCount(1);
            client.Tables["MyTable"].Items[0].Should().BeEquivalentTo(
                new DynamoDBMap
                {
                    ["id"] = 1, 
                    ["value1"] = 3, 
                    ["value2"] = "hello"
                });
        }
    }
}