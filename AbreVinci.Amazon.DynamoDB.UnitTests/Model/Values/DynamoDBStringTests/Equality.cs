// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBStringTests
{
    public class Equality
    {
        [Fact]
        public void SameStringsShouldBeEqual()
        {
            DynamoDBString str1 = "Hello";
            DynamoDBString str2 = "Hello";

            (str1 == str2).Should().BeTrue();
            (str1 != str2).Should().BeFalse();
            str1.Equals(str2).Should().BeTrue();
            str1.Equals((object)str2).Should().BeTrue();
            str1.Equals((DynamoDBKeyValue)str2).Should().BeTrue();
            str1.Equals((DynamoDBPrimitive)str2).Should().BeTrue();
            ((DynamoDBKeyValue)str1 == str2).Should().BeTrue();
            ((DynamoDBKeyValue)str1 != str2).Should().BeFalse();
            ((DynamoDBPrimitive)str1 == str2).Should().BeTrue();
            ((DynamoDBPrimitive)str1 != str2).Should().BeFalse();
            str1.GetHashCode().Should().Be(str2.GetHashCode());
        }

        [Fact]
        public void DifferentStringsShouldNotBeEqual()
        {
            DynamoDBString str1 = "Hello1";
            DynamoDBString str2 = "Hello2";

            (str1 == str2).Should().BeFalse();
            (str1 != str2).Should().BeTrue();
            str1.Equals(str2).Should().BeFalse();
            str1.Equals((object)str2).Should().BeFalse();
            str1.Equals((DynamoDBKeyValue)str2).Should().BeFalse();
            str1.Equals((DynamoDBPrimitive)str2).Should().BeFalse();
            ((DynamoDBKeyValue)str1 == str2).Should().BeFalse();
            ((DynamoDBKeyValue)str1 != str2).Should().BeTrue();
            ((DynamoDBPrimitive)str1 == str2).Should().BeFalse();
            ((DynamoDBPrimitive)str1 != str2).Should().BeTrue();
        }
    }
}