// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBBoolTests
{
    public class Conversion
    {
        [Fact]
        public void TrueShouldRoundtrip()
        {
            ((bool)(DynamoDBValue)true).Should().BeTrue();
            ((bool)(DynamoDBPrimitive)true).Should().BeTrue();
            ((bool)(DynamoDBBoolean)true).Should().BeTrue();
        }

        [Fact]
        public void FalseShouldRoundtrip()
        {
            ((bool)(DynamoDBValue)false).Should().BeFalse();
            ((bool)(DynamoDBPrimitive)false).Should().BeFalse();
            ((bool)(DynamoDBBoolean)false).Should().BeFalse();
        }
    }
}