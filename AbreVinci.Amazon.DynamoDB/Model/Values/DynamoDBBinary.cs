// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Immutable;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public class DynamoDBBinary : DynamoDBKeyValue
    {
        #region Fields

        private readonly ImmutableArray<byte> _value;
        private int? _hashCode;

        #endregion

        #region Constructors

        public DynamoDBBinary(byte[] value)
        {
            _value = ImmutableArray.Create(value);
        }

        public DynamoDBBinary(ImmutableArray<byte> value)
        {
            _value = value;
        }

        #endregion

        #region Conversion Operators

        public static implicit operator DynamoDBBinary(ImmutableArray<byte> value) => value == null || value.Length == 0 ? null : new DynamoDBBinary(value);
        public static implicit operator ImmutableArray<byte>(DynamoDBBinary value) => value?.AsImmutableByteArray() ?? ImmutableArray<byte>.Empty;
        public static implicit operator DynamoDBBinary(byte[] value) => value == null || value.Length == 0 ? null : new DynamoDBBinary(value);
        public static implicit operator byte[](DynamoDBBinary value) => value?.AsByteArray();

        #endregion

        #region Conversion Methods

        public new byte[] AsByteArray()
        {
            var array = new byte[_value.Length];
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            _value.CopyTo(array);
            return array;
        }

        public new ImmutableArray<byte> AsImmutableByteArray()
        {
            return _value;
        }

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            return Equals(other as DynamoDBBinary);
        }

        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            if (_hashCode != null)
                return _hashCode.Value;

            var s = 314;
            const int t = 159;
            var hash = 0;
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < _value.Length; ++i)
            {
                hash = hash * s + _value[i];
                s *= t;
            }

            _hashCode = hash;

            return _hashCode.Value;
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        public bool Equals(DynamoDBBinary other)
        {
            if (other == null || _value.Length != other._value.Length || GetHashCode() != other.GetHashCode())
                return false;

            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < _value.Length; ++i)
            {
                if (_value[i] != other._value[i])
                    return false;
            }

            return true;
        }

        public static bool operator ==(DynamoDBBinary lhs, DynamoDBBinary rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(DynamoDBBinary lhs, DynamoDBBinary rhs)
        {
            return !Equals(lhs, rhs);
        }

        #endregion
    }
}