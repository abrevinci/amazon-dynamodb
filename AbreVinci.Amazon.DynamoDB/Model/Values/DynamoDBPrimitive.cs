// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Collections.Immutable;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public abstract class DynamoDBPrimitive : DynamoDBValue, IEquatable<DynamoDBPrimitive>
    {
        #region Conversion Operators

        public static implicit operator DynamoDBPrimitive(string value) => (DynamoDBString)value;
        public static explicit operator string(DynamoDBPrimitive value) => (DynamoDBString)value;
        public static implicit operator DynamoDBPrimitive(byte[] value) => (DynamoDBBinary)value;
        public static explicit operator byte[](DynamoDBPrimitive value) => (DynamoDBBinary)value;
        public static implicit operator DynamoDBPrimitive(ImmutableArray<byte> value) => (DynamoDBBinary)value;
        public static explicit operator ImmutableArray<byte>(DynamoDBPrimitive value) => (DynamoDBBinary)value;
        public static implicit operator DynamoDBPrimitive(sbyte value) => (DynamoDBNumber)value;
        public static explicit operator sbyte(DynamoDBPrimitive value) => (sbyte)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(byte value) => (DynamoDBNumber)value;
        public static explicit operator byte(DynamoDBPrimitive value) => (byte)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(short value) => (DynamoDBNumber)value;
        public static explicit operator short(DynamoDBPrimitive value) => (short)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(ushort value) => (DynamoDBNumber)value;
        public static explicit operator ushort(DynamoDBPrimitive value) => (ushort)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(int value) => (DynamoDBNumber)value;
        public static explicit operator int(DynamoDBPrimitive value) => (int)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(uint value) => (DynamoDBNumber)value;
        public static explicit operator uint(DynamoDBPrimitive value) => (uint)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(long value) => (DynamoDBNumber)value;
        public static explicit operator long(DynamoDBPrimitive value) => (long)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(ulong value) => (DynamoDBNumber)value;
        public static explicit operator ulong(DynamoDBPrimitive value) => (ulong)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(float value) => (DynamoDBNumber)value;
        public static explicit operator float(DynamoDBPrimitive value) => (float)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(double value) => (DynamoDBNumber)value;
        public static explicit operator double(DynamoDBPrimitive value) => (double)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(decimal value) => (DynamoDBNumber)value;
        public static explicit operator decimal(DynamoDBPrimitive value) => (decimal)(DynamoDBNumber)value;
        public static implicit operator DynamoDBPrimitive(bool value) => (DynamoDBBoolean)value;
        public static explicit operator bool(DynamoDBPrimitive value) => (DynamoDBBoolean)value;

        #endregion

        #region Equality

        public abstract override bool Equals(object other);
        public abstract override int GetHashCode();

        public bool Equals(DynamoDBPrimitive other)
        {
            return Equals((object)other);
        }

        public static bool operator ==(DynamoDBPrimitive lhs, DynamoDBPrimitive rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(DynamoDBPrimitive lhs, DynamoDBPrimitive rhs)
        {
            return !Equals(lhs, rhs);
        }

        #endregion
    }
}