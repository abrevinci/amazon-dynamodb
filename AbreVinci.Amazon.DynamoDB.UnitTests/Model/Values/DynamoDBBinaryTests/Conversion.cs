// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Immutable;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBBinaryTests
{
    public class Conversion
    {
        [Fact]
        public void NullByteArraysShouldRoundtrip()
        {
            ((byte[])(DynamoDBValue)(byte[])null).Should().BeNull();
            ((byte[])(DynamoDBPrimitive)(byte[])null).Should().BeNull();
            ((byte[])(DynamoDBKeyValue)(byte[])null).Should().BeNull();
            ((byte[])(DynamoDBBinary)(byte[])null).Should().BeNull();
        }

        [Fact]
        public void EmptyByteArraysShouldConvertToNull()
        {
            ((byte[])(DynamoDBValue)new byte[] { }).Should().BeNull();
            ((byte[])(DynamoDBPrimitive)new byte[] { }).Should().BeNull();
            ((byte[])(DynamoDBKeyValue)new byte[] { }).Should().BeNull();
            ((byte[])(DynamoDBBinary)new byte[] { }).Should().BeNull();
        }

        [Fact]
        public void NonEmptyByteArraysShouldRoundtrip()
        {
            ((byte[])(DynamoDBValue)new byte[] {1, 2, 3}).Should().BeEquivalentTo(1, 2, 3);
            ((byte[])(DynamoDBPrimitive)new byte[] {1, 2, 3}).Should().BeEquivalentTo(1, 2, 3);
            ((byte[])(DynamoDBKeyValue)new byte[] {1, 2, 3}).Should().BeEquivalentTo(1, 2, 3);
            ((byte[])(DynamoDBBinary)new byte[] {1, 2, 3}).Should().BeEquivalentTo(1, 2, 3);
        }

        [Fact]
        public void EmptyImmutableByteArrayShouldConvertToEmpty()
        {
            ((ImmutableArray<byte>)(DynamoDBValue)ImmutableArray<byte>.Empty).Should().BeEmpty();
            ((ImmutableArray<byte>)(DynamoDBPrimitive)ImmutableArray<byte>.Empty).Should().BeEmpty();
            ((ImmutableArray<byte>)(DynamoDBKeyValue)ImmutableArray<byte>.Empty).Should().BeEmpty();
            ((ImmutableArray<byte>)(DynamoDBBinary)ImmutableArray<byte>.Empty).Should().BeEmpty();
        }

        [Fact]
        public void NonEmptyImmutableByteArrayShouldRoundtrip()
        {
            ((ImmutableArray<byte>)(DynamoDBValue)ImmutableArray.Create<byte>(1, 2, 3)).Should().BeEquivalentTo(1, 2, 3);
            ((ImmutableArray<byte>)(DynamoDBPrimitive)ImmutableArray.Create<byte>(1, 2, 3)).Should().BeEquivalentTo(1, 2, 3);
            ((ImmutableArray<byte>)(DynamoDBKeyValue)ImmutableArray.Create<byte>(1, 2, 3)).Should().BeEquivalentTo(1, 2, 3);
            ((ImmutableArray<byte>)(DynamoDBBinary)ImmutableArray.Create<byte>(1, 2, 3)).Should().BeEquivalentTo(1, 2, 3);
        }
    }
}