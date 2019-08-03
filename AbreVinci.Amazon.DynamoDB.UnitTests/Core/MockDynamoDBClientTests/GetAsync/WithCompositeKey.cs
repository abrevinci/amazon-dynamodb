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
    public class WithCompositeKey
    {
        [Fact]
        public void ShouldThrowWhenTableDoesNotExist()
        {
            // Arrange
            var client = new MockDynamoDBClient();
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, "sort", 2, false, null);

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
                    ["MyTable"] = new MockDynamoDBTableContent("id", "sort")
                }
            };
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, "sort", 2, false, null);

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
                    ["MyTable"] = new MockDynamoDBTableContent("id", "sort")
                    {
                        ConsistentReadOnlyItems =
                        {
                            new DynamoDBMap
                            {
                                ["id"] = 1,
                                ["sort"] = 2,
                                ["value"] = "hello"
                            }
                        }
                    }
                }
            };
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, "sort", 2, false, null);

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
                    ["MyTable"] = new MockDynamoDBTableContent("id", "sort")
                    {
                        Items =
                        {
                            new DynamoDBMap
                            {
                                ["id"] = 1,
                                ["sort"] = 2,
                                ["value"] = "hello"
                            }
                        }
                    }
                }
            };
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, "sort", 2, false, null);

            // Act
            var result = await client.GetAsync(request);

            // Assert
            result.Should().BeEquivalentTo(
                new DynamoDBMap
                {
                    ["id"] = 1,
                    ["sort"] = 2,
                    ["value"] = "hello"
                });
        }
    }
}