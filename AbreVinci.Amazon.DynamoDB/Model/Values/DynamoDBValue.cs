// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Immutable;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public abstract class DynamoDBValue
    {
        #region Conversion Operators

        public static implicit operator DynamoDBValue(string value) => (DynamoDBString)value;
        public static explicit operator string(DynamoDBValue value) => (DynamoDBString)value;
        public static implicit operator DynamoDBValue(byte[] value) => (DynamoDBBinary)value;
        public static explicit operator byte[](DynamoDBValue value) => (DynamoDBBinary)value;
        public static implicit operator DynamoDBValue(ImmutableArray<byte> value) => (DynamoDBBinary)value;
        public static explicit operator ImmutableArray<byte>(DynamoDBValue value) => (DynamoDBBinary)value;
        public static implicit operator DynamoDBValue(sbyte value) => (DynamoDBNumber)value;
        public static explicit operator sbyte(DynamoDBValue value) => (sbyte)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(byte value) => (DynamoDBNumber)value;
        public static explicit operator byte(DynamoDBValue value) => (byte)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(short value) => (DynamoDBNumber)value;
        public static explicit operator short(DynamoDBValue value) => (short)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(ushort value) => (DynamoDBNumber)value;
        public static explicit operator ushort(DynamoDBValue value) => (ushort)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(int value) => (DynamoDBNumber)value;
        public static explicit operator int(DynamoDBValue value) => (int)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(uint value) => (DynamoDBNumber)value;
        public static explicit operator uint(DynamoDBValue value) => (uint)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(long value) => (DynamoDBNumber)value;
        public static explicit operator long(DynamoDBValue value) => (long)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(ulong value) => (DynamoDBNumber)value;
        public static explicit operator ulong(DynamoDBValue value) => (ulong)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(float value) => (DynamoDBNumber)value;
        public static explicit operator float(DynamoDBValue value) => (float)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(double value) => (DynamoDBNumber)value;
        public static explicit operator double(DynamoDBValue value) => (double)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(decimal value) => (DynamoDBNumber)value;
        public static explicit operator decimal(DynamoDBValue value) => (decimal)(DynamoDBNumber)value;
        public static implicit operator DynamoDBValue(bool value) => (DynamoDBBoolean)value;
        public static explicit operator bool(DynamoDBValue value) => (DynamoDBBoolean)value;

        #endregion

        #region Conversion Methods

        public string AsString() => ((DynamoDBString)this).AsString();
        public byte[] AsByteArray() => ((DynamoDBBinary)this).AsByteArray();
        public ImmutableArray<byte> AsImmutableByteArray() => ((DynamoDBBinary)this).AsImmutableByteArray();
        public sbyte AsSByte() => ((DynamoDBNumber)this).AsSByte();
        public byte AsByte() => ((DynamoDBNumber)this).AsByte();
        public short AsInt16() => ((DynamoDBNumber)this).AsInt16();
        public ushort AsUInt16() => ((DynamoDBNumber)this).AsUInt16();
        public int AsInt32() => ((DynamoDBNumber)this).AsInt32();
        public uint AsUInt32() => ((DynamoDBNumber)this).AsUInt32();
        public long AsInt64() => ((DynamoDBNumber)this).AsInt64();
        public ulong AsUInt64() => ((DynamoDBNumber)this).AsUInt64();
        public float AsSingle() => ((DynamoDBNumber)this).AsSingle();
        public double AsDouble() => ((DynamoDBNumber)this).AsDouble();
        public decimal AsDecimal() => ((DynamoDBNumber)this).AsDecimal();
        public bool AsBoolean() => ((DynamoDBBoolean)this).AsBoolean();

        #endregion
    }
}