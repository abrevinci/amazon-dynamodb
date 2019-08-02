// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBAttributePath : IEquatable<DynamoDBAttributePath>, IEquatable<string>
    {
        #region Constructor

        public DynamoDBAttributePath(string path)
        {
            Path = path.Split('.');
        }

        #endregion

        #region Properties

        public IReadOnlyList<string> Path { get; }

        #endregion

        #region Conversion

        public static implicit operator DynamoDBAttributePath(string path) => new DynamoDBAttributePath(path);

        public override string ToString()
        {
            return string.Join(".", Path);
        }

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            switch (other)
            {
                case DynamoDBAttributePath attr:
                    return Equals(attr);
                case string path:
                    return Equals(path);
            }

            return false;
        }

        public bool Equals(string other)
        {
            return other != null && ToString() == other;
        }

        public bool Equals(DynamoDBAttributePath other)
        {
            return other != null && ToString() == other.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(DynamoDBAttributePath lhs, DynamoDBAttributePath rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(DynamoDBAttributePath lhs, DynamoDBAttributePath rhs)
        {
            return !Equals(lhs, rhs);
        }

        #endregion
    }
}