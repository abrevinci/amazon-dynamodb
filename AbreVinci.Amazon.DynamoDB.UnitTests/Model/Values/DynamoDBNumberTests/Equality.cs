// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBNumberTests
{
    public class Equality
    {
        [Fact]
        public void SameNumbersShouldBeEqual()
        {
            DynamoDBNumber num1 = 123;
            DynamoDBNumber num2 = 123;

            (num1 == num2).Should().BeTrue();
            (num1 != num2).Should().BeFalse();
            num1.Equals(num2).Should().BeTrue();
            num1.Equals((object)num2).Should().BeTrue();
            num1.Equals((DynamoDBKeyValue)num2).Should().BeTrue();
            num1.Equals((DynamoDBPrimitive)num2).Should().BeTrue();
            ((DynamoDBKeyValue)num1 == num2).Should().BeTrue();
            ((DynamoDBKeyValue)num1 != num2).Should().BeFalse();
            ((DynamoDBPrimitive)num1 == num2).Should().BeTrue();
            ((DynamoDBPrimitive)num1 != num2).Should().BeFalse();
            num1.GetHashCode().Should().Be(num2.GetHashCode());
        }

        [Fact]
        public void DifferentNumbersShouldNotBeEqual()
        {
            DynamoDBNumber num1 = 123;
            DynamoDBNumber num2 = 124;

            (num1 == num2).Should().BeFalse();
            (num1 != num2).Should().BeTrue();
            num1.Equals(num2).Should().BeFalse();
            num1.Equals((object)num2).Should().BeFalse();
            num1.Equals((DynamoDBKeyValue)num2).Should().BeFalse();
            num1.Equals((DynamoDBPrimitive)num2).Should().BeFalse();
            ((DynamoDBKeyValue)num1 == num2).Should().BeFalse();
            ((DynamoDBKeyValue)num1 != num2).Should().BeTrue();
            ((DynamoDBPrimitive)num1 == num2).Should().BeFalse();
            ((DynamoDBPrimitive)num1 != num2).Should().BeTrue();
        }
    }
}