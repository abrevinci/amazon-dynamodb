// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public class DynamoDBString : DynamoDBKeyValue, IEquatable<DynamoDBString>
    {
        #region Fields

        private readonly string _value;

        #endregion

        #region Constructor

        public DynamoDBString(string value)
        {
            _value = value;
        }

        #endregion

        #region Conversion Operators

        public static implicit operator DynamoDBString(string value) => string.IsNullOrEmpty(value) ? null : new DynamoDBString(value);
        public static implicit operator string(DynamoDBString value) => value?.AsString();

        #endregion

        #region Conversion Methods

        public new string AsString() => _value;

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            return Equals(other as DynamoDBString);
        }

        public bool Equals(DynamoDBString other)
        {
            return other != null && _value == other._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(DynamoDBString lhs, DynamoDBString rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(DynamoDBString lhs, DynamoDBString rhs)
        {
            return !Equals(lhs, rhs);
        }

        #endregion
    }
}