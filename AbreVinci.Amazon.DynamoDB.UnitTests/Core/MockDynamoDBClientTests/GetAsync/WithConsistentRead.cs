// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Mock;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.MockDynamoDBClientTests.GetAsync
{
    public class WithConsistentRead
    {
        [Fact]
        public async Task ShouldReturnItemWhenItemOnlyExistsForConsistentReads()
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
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, true, null);

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