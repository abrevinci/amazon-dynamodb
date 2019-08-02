// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Collections.Immutable;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public abstract class DynamoDBKeyValue : DynamoDBPrimitive, IEquatable<DynamoDBKeyValue>
    {
        #region Conversion Operators

        public static implicit operator DynamoDBKeyValue(string value) => (DynamoDBString)value;
        public static explicit operator string(DynamoDBKeyValue value) => (DynamoDBString)value;
        public static implicit operator DynamoDBKeyValue(byte[] value) => (DynamoDBBinary)value;
        public static explicit operator byte[](DynamoDBKeyValue value) => (DynamoDBBinary)value;
        public static implicit operator DynamoDBKeyValue(ImmutableArray<byte> value) => (DynamoDBBinary)value;
        public static explicit operator ImmutableArray<byte>(DynamoDBKeyValue value) => (DynamoDBBinary)value;
        public static implicit operator DynamoDBKeyValue(sbyte value) => (DynamoDBNumber)value;
        public static explicit operator sbyte(DynamoDBKeyValue value) => (sbyte)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(byte value) => (DynamoDBNumber)value;
        public static explicit operator byte(DynamoDBKeyValue value) => (byte)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(short value) => (DynamoDBNumber)value;
        public static explicit operator short(DynamoDBKeyValue value) => (short)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(ushort value) => (DynamoDBNumber)value;
        public static explicit operator ushort(DynamoDBKeyValue value) => (ushort)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(int value) => (DynamoDBNumber)value;
        public static explicit operator int(DynamoDBKeyValue value) => (int)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(uint value) => (DynamoDBNumber)value;
        public static explicit operator uint(DynamoDBKeyValue value) => (uint)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(long value) => (DynamoDBNumber)value;
        public static explicit operator long(DynamoDBKeyValue value) => (long)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(ulong value) => (DynamoDBNumber)value;
        public static explicit operator ulong(DynamoDBKeyValue value) => (ulong)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(float value) => (DynamoDBNumber)value;
        public static explicit operator float(DynamoDBKeyValue value) => (float)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(double value) => (DynamoDBNumber)value;
        public static explicit operator double(DynamoDBKeyValue value) => (double)(DynamoDBNumber)value;
        public static implicit operator DynamoDBKeyValue(decimal value) => (DynamoDBNumber)value;
        public static explicit operator decimal(DynamoDBKeyValue value) => (decimal)(DynamoDBNumber)value;

        #endregion

        #region Equality

        public abstract override bool Equals(object other);
        public abstract override int GetHashCode();

        public bool Equals(DynamoDBKeyValue other)
        {
            return Equals((object)other);
        }

        public static bool operator ==(DynamoDBKeyValue lhs, DynamoDBKeyValue rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(DynamoDBKeyValue lhs, DynamoDBKeyValue rhs)
        {
            return !Equals(lhs, rhs);
        }

        #endregion
    }
}