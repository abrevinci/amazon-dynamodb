// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Mock;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.MockDynamoDBClientTests.GetAsync
{
    public class WithPartitionKey
    {
        [Fact]
        public void ShouldThrowWhenTableDoesNotExist()
        {
            // Arrange
            var client = new MockDynamoDBClient();
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, false, null);

            // Act
            Func<Task> f = async () => { await client.GetAsync(request); };

            // Assert
            f.Should().Throw<Exception>();
        }

        [Fact]
        public async Task ShouldReturnNullWhenItemDoesNotExist()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                }
            };
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, false, null);

            // Act
            var result = await client.GetAsync(request);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ShouldReturnNullWhenItemOnlyExistsForConsistentReads()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent("id")
                    {
                        ConsistentReadOnlyItems =
                        {
                            new DynamoDBMap
                            {
                                ["id"] = 1,
                                ["value1"] = 3,
                                ["value2"] = "hello"
                            }
                        }
                    }
                }
            };
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, false, null);

            // Act
            var result = await client.GetAsync(request);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ShouldReturnItemWhenItExists()
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
                                ["value1"] = 3,
                                ["value2"] = "hello"
                            }
                        }
                    }
                }
            };
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, false, null);

            // Act
            var result = await client.GetAsync(request);

            // Assert
            result.Should().BeEquivalentTo(
                new DynamoDBMap
                {
                    ["id"] = 1,
                    ["value1"] = 3,
                    ["value2"] = "hello"
                });
        }
    }
}