// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Globalization;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public class DynamoDBNumber : DynamoDBKeyValue, IEquatable<DynamoDBNumber>
    {
        #region Fields

        private readonly string _value;

        #endregion

        #region Constructors

        private DynamoDBNumber(string value)
        {
            _value = value;
        }

        public DynamoDBNumber(sbyte value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(byte value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(short value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(ushort value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(int value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(uint value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(long value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(ulong value) : this(value.ToString("D", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(float value) : this(value.ToString("G9", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(double value) : this(value.ToString("G17", CultureInfo.InvariantCulture))
        {
        }

        public DynamoDBNumber(decimal value) : this(value.ToString(CultureInfo.InvariantCulture))
        {
        }

        #endregion

        #region Conversion Operators

        public static implicit operator DynamoDBNumber(sbyte value) => new DynamoDBNumber(value);
        public static explicit operator sbyte(DynamoDBNumber value) => value.AsSByte();
        public static implicit operator DynamoDBNumber(byte value) => new DynamoDBNumber(value);
        public static explicit operator byte(DynamoDBNumber value) => value.AsByte();
        public static implicit operator DynamoDBNumber(short value) => new DynamoDBNumber(value);
        public static explicit operator short(DynamoDBNumber value) => value.AsInt16();
        public static implicit operator DynamoDBNumber(ushort value) => new DynamoDBNumber(value);
        public static explicit operator ushort(DynamoDBNumber value) => value.AsUInt16();
        public static implicit operator DynamoDBNumber(int value) => new DynamoDBNumber(value);
        public static explicit operator int(DynamoDBNumber value) => value.AsInt32();
        public static implicit operator DynamoDBNumber(uint value) => new DynamoDBNumber(value);
        public static explicit operator uint(DynamoDBNumber value) => value.AsUInt32();
        public static implicit operator DynamoDBNumber(long value) => new DynamoDBNumber(value);
        public static explicit operator long(DynamoDBNumber value) => value.AsInt64();
        public static implicit operator DynamoDBNumber(ulong value) => new DynamoDBNumber(value);
        public static explicit operator ulong(DynamoDBNumber value) => value.AsUInt64();
        public static implicit operator DynamoDBNumber(float value) => new DynamoDBNumber(value);
        public static explicit operator float(DynamoDBNumber value) => value.AsSingle();
        public static implicit operator DynamoDBNumber(double value) => new DynamoDBNumber(value);
        public static explicit operator double(DynamoDBNumber value) => value.AsDouble();
        public static implicit operator DynamoDBNumber(decimal value) => new DynamoDBNumber(value);
        public static explicit operator decimal(DynamoDBNumber value) => value.AsDecimal();

        #endregion

        #region Conversion Methods

        public new sbyte AsSByte() => (sbyte)AsDecimal();
        public new byte AsByte() => (byte)AsDecimal();
        public new short AsInt16() => (short)AsDecimal();
        public new ushort AsUInt16() => (ushort)AsDecimal();
        public new int AsInt32() => (int)AsDecimal();
        public new uint AsUInt32() => (uint)AsDecimal();
        public new long AsInt64() => (long)AsDecimal();
        public new ulong AsUInt64() => (ulong)AsDecimal();
        public new float AsSingle() => (float)AsDouble();

        public new double AsDouble()
        {
            return double.Parse(_value, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
        }

        public new decimal AsDecimal()
        {
            return decimal.Parse(_value, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
        }

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            return Equals(other as DynamoDBNumber);
        }

        public bool Equals(DynamoDBNumber other)
        {
            return other != null && _value == other._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(DynamoDBNumber lhs, DynamoDBNumber rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(DynamoDBNumber lhs, DynamoDBNumber rhs)
        {
            return !Equals(lhs, rhs);
        }

        #endregion
    }
}