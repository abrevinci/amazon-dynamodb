// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public class DynamoDBBoolean : DynamoDBPrimitive, IEquatable<DynamoDBBoolean>
    {
        public static DynamoDBBoolean True { get; } = new DynamoDBBoolean(true);
        public static DynamoDBBoolean False { get; } = new DynamoDBBoolean(false);

        #region Fields

        private readonly bool _value;

        #endregion

        #region Constructor

        private DynamoDBBoolean(bool value)
        {
            _value = value;
        }

        #endregion

        #region Conversion Operators

        public static implicit operator DynamoDBBoolean(bool value) => value ? True : False;
        public static implicit operator bool(DynamoDBBoolean value) => value.AsBoolean();

        #endregion

        #region Conversion Methods

        public new bool AsBoolean() => _value;

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            return ReferenceEquals(this, other as DynamoDBBoolean);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public bool Equals(DynamoDBBoolean other)
        {
            return ReferenceEquals(this, other);
        }

        public static bool operator ==(DynamoDBBoolean lhs, DynamoDBBoolean rhs)
        {
            return ReferenceEquals(lhs, rhs);
        }

        public static bool operator !=(DynamoDBBoolean lhs, DynamoDBBoolean rhs)
        {
            return !ReferenceEquals(lhs, rhs);
        }

        #endregion
    }
}