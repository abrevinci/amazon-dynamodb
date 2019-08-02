// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Mock;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Core.MockDynamoDBClientTests.GetAsync
{
    public class WithProjection
    {
        [Fact]
        public async Task ShouldReturnItemWithOnlySelectedAttributesWhenItExists()
        {
            // Arrange
            var client = new MockDynamoDBClient
            {
                Tables =
                {
                    ["MyTable"] = new MockDynamoDBTableContent
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
            var request = new DynamoDBTableGetRequest("MyTable", "id", 1, false, new DynamoDBAttributePath[] {"id", "value1"});

            // Act
            var result = await client.GetAsync(request);

            // Assert
            result.Should().BeEquivalentTo(
                new DynamoDBMap
                {
                    ["id"] = 1,
                    ["value1"] = 3
                });
        }
    }
}