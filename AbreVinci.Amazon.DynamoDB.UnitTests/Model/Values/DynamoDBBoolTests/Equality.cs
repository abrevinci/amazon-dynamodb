// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBBoolTests
{
    public class Equality
    {
        [Fact]
        public void SameBooleansShouldBeEqual()
        {
            DynamoDBBoolean bool1 = true;
            DynamoDBBoolean bool2 = true;

            (bool1 == bool2).Should().BeTrue();
            (bool1 != bool2).Should().BeFalse();
            bool1.Equals(bool2).Should().BeTrue();
            bool1.Equals((object)bool2).Should().BeTrue();
            bool1.Equals((DynamoDBPrimitive)bool2).Should().BeTrue();
            ((DynamoDBPrimitive)bool1 == bool2).Should().BeTrue();
            ((DynamoDBPrimitive)bool1 != bool2).Should().BeFalse();
            bool1.GetHashCode().Should().Be(bool2.GetHashCode());
        }

        [Fact]
        public void DifferentBooleansShouldNotBeEqual()
        {
            DynamoDBBoolean bool1 = true;
            DynamoDBBoolean bool2 = false;

            (bool1 == bool2).Should().BeFalse();
            (bool1 != bool2).Should().BeTrue();
            bool1.Equals(bool2).Should().BeFalse();
            bool1.Equals((object)bool2).Should().BeFalse();
            bool1.Equals((DynamoDBPrimitive)bool2).Should().BeFalse();
            ((DynamoDBPrimitive)bool1 == bool2).Should().BeFalse();
            ((DynamoDBPrimitive)bool1 != bool2).Should().BeTrue();
        }
    }
}