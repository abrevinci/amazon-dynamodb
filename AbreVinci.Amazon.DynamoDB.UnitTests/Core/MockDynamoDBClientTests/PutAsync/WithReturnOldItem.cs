// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Mock;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.MockDynamoDBClientTests.PutAsync
{
    public class WithReturnOldItem
    {
        [Fact]
        public async Task ShouldReturnNullWhenOldItemDoesNotExist()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                }
            };
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, true);

            // Act
            var result = await client.PutAsync(request);

            // Assert
            result.Should().BeNull();
        }
        
        [Fact]
        public async Task ShouldReturnOldItemWhenItExists()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                    {
                        Items =
                        {
                            new DynamoDBMap
                            {
                                ["id"] = 1,
                                ["value1"] = 2,
                                ["value2"] = "hi"
                            }
                        }
                    }
                }
            };
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, true);

            // Act
            var result = await client.PutAsync(request);

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
        public async Task ShouldReplaceOldItemInTable()
        {
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                    {
                        Items =
                        {
                            new DynamoDBMap
                            {
                                ["id"] = 1,
                                ["value1"] = 2,
                                ["value2"] = "hi"
                            }
                        }
                    }
                }
            };
            var request = new DynamoDBTablePutRequest("MyTable", new DynamoDBMap {["id"] = 1, ["value1"] = 3, ["value2"] = "hello"}, true);

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