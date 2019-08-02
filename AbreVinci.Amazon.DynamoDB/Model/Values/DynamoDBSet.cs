// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public class DynamoDBSet<T> : DynamoDBValue, ISet<T>, IReadOnlyCollection<T> where T : DynamoDBKeyValue
    {
        #region Fields

        private readonly HashSet<T> _values;

        #endregion

        #region Constructors

        public DynamoDBSet()
        {
            _values = new HashSet<T>();
        }

        public DynamoDBSet(IEnumerable<T> values)
        {
            _values = new HashSet<T>(values);
        }

        #endregion

        #region ISet<T>

        public bool Add(T item) => _values.Add(item);
        public void UnionWith(IEnumerable<T> other) => _values.UnionWith(other);
        public void IntersectWith(IEnumerable<T> other) => _values.IntersectWith(other);
        public void ExceptWith(IEnumerable<T> other) => _values.ExceptWith(other);
        public void SymmetricExceptWith(IEnumerable<T> other) => _values.SymmetricExceptWith(other);
        public bool IsSubsetOf(IEnumerable<T> other) => _values.IsSubsetOf(other);
        public bool IsSupersetOf(IEnumerable<T> other) => _values.IsSupersetOf(other);
        public bool IsProperSupersetOf(IEnumerable<T> other) => _values.IsProperSupersetOf(other);
        public bool IsProperSubsetOf(IEnumerable<T> other) => _values.IsProperSubsetOf(other);
        public bool Overlaps(IEnumerable<T> other) => _values.Overlaps(other);
        public bool SetEquals(IEnumerable<T> other) => _values.SetEquals(other);

        #endregion

        #region ICollection<DynamoDBValue>

        public int Count => _values.Count;
        public bool IsReadOnly => ((ICollection<DynamoDBValue>)_values).IsReadOnly;
        void ICollection<T>.Add(T item) => ((ICollection<DynamoDBValue>)_values).Add(item);
        public void Clear() => _values.Clear();
        public bool Contains(T item) => _values.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => _values.CopyTo(array, arrayIndex);
        public bool Remove(T item) => _values.Remove(item);

        #endregion

        #region IEnumerable<T>

        public IEnumerator<T> GetEnumerator() => _values.GetEnumerator();

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

        #endregion
    }
}