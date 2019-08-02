// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBStringTests
{
    public class Conversion
    {
        [Fact]
        public void NullStringsShouldRoundtrip()
        {
            ((string)(DynamoDBValue)(string)null).Should().BeNull();
            ((string)(DynamoDBPrimitive)(string)null).Should().BeNull();
            ((string)(DynamoDBKeyValue)(string)null).Should().BeNull();
            ((string)(DynamoDBString)(string)null).Should().BeNull();
        }

        [Fact]
        public void EmptyStringsShouldConvertToNull()
        {
            ((string)(DynamoDBValue)"").Should().BeNull();
            ((string)(DynamoDBPrimitive)"").Should().BeNull();
            ((string)(DynamoDBKeyValue)"").Should().BeNull();
            ((string)(DynamoDBString)"").Should().BeNull();
        }

        [Fact]
        public void NonEmptyStringsShouldRoundtrip()
        {
            ((string)(DynamoDBValue)"Hello").Should().Be("Hello");
            ((string)(DynamoDBPrimitive)"Hello").Should().Be("Hello");
            ((string)(DynamoDBKeyValue)"Hello").Should().Be("Hello");
            ((string)(DynamoDBString)"Hello").Should().Be("Hello");
        }
    }
}