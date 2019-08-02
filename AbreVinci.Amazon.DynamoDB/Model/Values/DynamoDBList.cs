// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public class DynamoDBList : DynamoDBValue, IList<DynamoDBValue>, IReadOnlyList<DynamoDBValue>
    {
        #region Fields

        private readonly List<DynamoDBValue> _values;

        #endregion

        #region Constructors

        public DynamoDBList()
        {
            _values = new List<DynamoDBValue>();
        }

        public DynamoDBList(IEnumerable<DynamoDBValue> values)
        {
            _values = new List<DynamoDBValue>(values);
        }

        #endregion

        #region IList<DynamoDBValue>

        public DynamoDBValue this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }

        public int IndexOf(DynamoDBValue item) => _values.IndexOf(item);
        public void Insert(int index, DynamoDBValue item) => _values.Insert(index, item);
        public void RemoveAt(int index) => _values.RemoveAt(index);

        #endregion

        #region ICollection<DynamoDBValue>

        public int Count => _values.Count;
        public bool IsReadOnly => ((ICollection<DynamoDBValue>)_values).IsReadOnly;
        public void Add(DynamoDBValue item) => _values.Add(item);
        public void Clear() => _values.Clear();
        public bool Contains(DynamoDBValue item) => _values.Contains(item);
        public void CopyTo(DynamoDBValue[] array, int arrayIndex) => _values.CopyTo(array, arrayIndex);
        public bool Remove(DynamoDBValue item) => _values.Remove(item);

        #endregion

        #region IEnumerable<DynamoDBValue>

        public IEnumerator<DynamoDBValue> GetEnumerator() => _values.GetEnumerator();

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

        #endregion
    }
}