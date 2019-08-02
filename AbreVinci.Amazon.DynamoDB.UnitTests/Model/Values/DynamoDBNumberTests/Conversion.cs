// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using FluentAssertions;
using Xunit;

namespace AbreVinci.Amazon.DynamoDB.UnitTests.Model.Values.DynamoDBNumberTests
{
    public class Conversion
    {
        [Fact]
        public void SByteValueShouldRoundtrip()
        {
            ((sbyte)(DynamoDBValue)(sbyte)34).Should().Be(34);
            ((sbyte)(DynamoDBValue)(sbyte)-34).Should().Be(-34);
            ((sbyte)(DynamoDBPrimitive)(sbyte)34).Should().Be(34);
            ((sbyte)(DynamoDBPrimitive)(sbyte)-34).Should().Be(-34);
            ((sbyte)(DynamoDBKeyValue)(sbyte)34).Should().Be(34);
            ((sbyte)(DynamoDBKeyValue)(sbyte)-34).Should().Be(-34);
            ((sbyte)(DynamoDBNumber)(sbyte)34).Should().Be(34);
            ((sbyte)(DynamoDBNumber)(sbyte)-34).Should().Be(-34);
        }

        [Fact]
        public void ByteValueShouldRoundtrip()
        {
            ((byte)(DynamoDBValue)(byte)34).Should().Be(34);
            ((byte)(DynamoDBPrimitive)(byte)34).Should().Be(34);
            ((byte)(DynamoDBKeyValue)(byte)34).Should().Be(34);
            ((byte)(DynamoDBNumber)(byte)34).Should().Be(34);
        }

        [Fact]
        public void Int16ValueShouldRoundtrip()
        {
            ((short)(DynamoDBValue)(short)1234).Should().Be(1234);
            ((short)(DynamoDBValue)(short)-1234).Should().Be(-1234);
            ((short)(DynamoDBPrimitive)(short)1234).Should().Be(1234);
            ((short)(DynamoDBPrimitive)(short)-1234).Should().Be(-1234);
            ((short)(DynamoDBKeyValue)(short)1234).Should().Be(1234);
            ((short)(DynamoDBKeyValue)(short)-1234).Should().Be(-1234);
            ((short)(DynamoDBNumber)(short)1234).Should().Be(1234);
            ((short)(DynamoDBNumber)(short)-1234).Should().Be(-1234);
        }

        [Fact]
        public void UInt16ValueShouldRoundtrip()
        {
            ((ushort)(DynamoDBValue)(ushort)1234).Should().Be(1234);
            ((ushort)(DynamoDBPrimitive)(ushort)1234).Should().Be(1234);
            ((ushort)(DynamoDBKeyValue)(ushort)1234).Should().Be(1234);
            ((ushort)(DynamoDBNumber)(ushort)1234).Should().Be(1234);
        }

        [Fact]
        public void Int32ValueShouldRoundtrip()
        {
            ((int)(DynamoDBValue)1234567).Should().Be(1234567);
            ((int)(DynamoDBValue)(-1234567)).Should().Be(-1234567);
            ((int)(DynamoDBPrimitive)1234567).Should().Be(1234567);
            ((int)(DynamoDBPrimitive)(-1234567)).Should().Be(-1234567);
            ((int)(DynamoDBKeyValue)1234567).Should().Be(1234567);
            ((int)(DynamoDBKeyValue)(-1234567)).Should().Be(-1234567);
            ((int)(DynamoDBNumber)1234567).Should().Be(1234567);
            ((int)(DynamoDBNumber)(-1234567)).Should().Be(-1234567);
        }

        [Fact]
        public void UInt32ValueShouldRoundtrip()
        {
            ((uint)(DynamoDBValue)1234567u).Should().Be(1234567u);
            ((uint)(DynamoDBPrimitive)1234567u).Should().Be(1234567u);
            ((uint)(DynamoDBKeyValue)1234567u).Should().Be(1234567u);
            ((uint)(DynamoDBNumber)1234567u).Should().Be(1234567u);
        }

        [Fact]
        public void Int64ValueShouldRoundtrip()
        {
            ((long)(DynamoDBValue)123456789123456789L).Should().Be(123456789123456789L);
            ((long)(DynamoDBValue)(-123456789123456789L)).Should().Be(-123456789123456789L);
            ((long)(DynamoDBPrimitive)123456789123456789L).Should().Be(123456789123456789L);
            ((long)(DynamoDBPrimitive)(-123456789123456789L)).Should().Be(-123456789123456789L);
            ((long)(DynamoDBKeyValue)123456789123456789L).Should().Be(123456789123456789L);
            ((long)(DynamoDBKeyValue)(-123456789123456789L)).Should().Be(-123456789123456789L);
            ((long)(DynamoDBNumber)123456789123456789L).Should().Be(123456789123456789L);
            ((long)(DynamoDBNumber)(-123456789123456789L)).Should().Be(-123456789123456789L);
        }

        [Fact]
        public void UInt64ValueShouldRoundtrip()
        {
            ((ulong)(DynamoDBValue)123456789123456789ul).Should().Be(123456789123456789ul);
            ((ulong)(DynamoDBPrimitive)123456789123456789ul).Should().Be(123456789123456789ul);
            ((ulong)(DynamoDBKeyValue)123456789123456789ul).Should().Be(123456789123456789ul);
            ((ulong)(DynamoDBNumber)123456789123456789ul).Should().Be(123456789123456789ul);
        }

        [Fact]
        public void SingleValueShouldRoundtrip()
        {
            ((float)(DynamoDBValue)1.23f).Should().Be(1.23f);
            ((float)(DynamoDBPrimitive)1.23f).Should().Be(1.23f);
            ((float)(DynamoDBKeyValue)1.23f).Should().Be(1.23f);
            ((float)(DynamoDBNumber)1.23f).Should().Be(1.23f);
        }

        [Fact]
        public void DoubleValueShouldRoundtrip()
        {
            ((double)(DynamoDBValue)1.23456789123456789).Should().Be(1.23456789123456789);
            ((double)(DynamoDBPrimitive)1.23456789123456789).Should().Be(1.23456789123456789);
            ((double)(DynamoDBKeyValue)1.23456789123456789).Should().Be(1.23456789123456789);
            ((double)(DynamoDBNumber)1.23456789123456789).Should().Be(1.23456789123456789);
        }

        [Fact]
        public void DecimalValueShouldRoundtrip()
        {
            ((decimal)(DynamoDBValue)1.23456789m).Should().Be(1.23456789m);
            ((decimal)(DynamoDBPrimitive)1.23456789m).Should().Be(1.23456789m);
            ((decimal)(DynamoDBKeyValue)1.23456789m).Should().Be(1.23456789m);
            ((decimal)(DynamoDBNumber)1.23456789m).Should().Be(1.23456789m);
        }
    }
}