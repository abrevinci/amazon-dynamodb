// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBBinaryTests
{
    public class Equality
    {
        [Fact]
        public void SameBinariesShouldBeEqual()
        {
            DynamoDBBinary bin1 = new byte[] {1, 2, 3};
            DynamoDBBinary bin2 = new byte[] {1, 2, 3};

            (bin1 == bin2).Should().BeTrue();
            (bin1 != bin2).Should().BeFalse();
            bin1.Equals(bin2).Should().BeTrue();
            bin1.Equals((object)bin2).Should().BeTrue();
            bin1.Equals((DynamoDBKeyValue)bin2).Should().BeTrue();
            bin1.Equals((DynamoDBPrimitive)bin2).Should().BeTrue();
            ((DynamoDBKeyValue)bin1 == bin2).Should().BeTrue();
            ((DynamoDBKeyValue)bin1 != bin2).Should().BeFalse();
            ((DynamoDBPrimitive)bin1 == bin2).Should().BeTrue();
            ((DynamoDBPrimitive)bin1 != bin2).Should().BeFalse();
            bin1.GetHashCode().Should().Be(bin2.GetHashCode());
        }

        [Fact]
        public void DifferentBinariesShouldNotBeEqual()
        {
            DynamoDBBinary bin1 = new byte[] {1, 2, 3};
            DynamoDBBinary bin2 = new byte[] {1, 2, 4};

            (bin1 == bin2).Should().BeFalse();
            (bin1 != bin2).Should().BeTrue();
            bin1.Equals(bin2).Should().BeFalse();
            bin1.Equals((object)bin2).Should().BeFalse();
            bin1.Equals((DynamoDBKeyValue)bin2).Should().BeFalse();
            bin1.Equals((DynamoDBPrimitive)bin2).Should().BeFalse();
            ((DynamoDBKeyValue)bin1 == bin2).Should().BeFalse();
            ((DynamoDBKeyValue)bin1 != bin2).Should().BeTrue();
            ((DynamoDBPrimitive)bin1 == bin2).Should().BeFalse();
            ((DynamoDBPrimitive)bin1 != bin2).Should().BeTrue();
        }
    }
}