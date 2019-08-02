// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model.Values
{
    [PublicAPI]
    public class DynamoDBMap : DynamoDBValue, IDictionary<string, DynamoDBValue>, IReadOnlyDictionary<string, DynamoDBValue>
    {
        #region Fields

        private readonly Dictionary<string, DynamoDBValue> _values;

        #endregion

        #region Constructors

        public DynamoDBMap()
        {
            _values = new Dictionary<string, DynamoDBValue>();
        }

        public DynamoDBMap(IDictionary<string, DynamoDBValue> values)
        {
            _values = new Dictionary<string, DynamoDBValue>(values);
        }

        #endregion

        #region IDictionary<string, DynamoDBValue>

        public DynamoDBValue this[string key]
        {
            get => _values[key];
            set => _values[key] = value;
        }

        public ICollection<string> Keys => _values.Keys;
        public ICollection<DynamoDBValue> Values => _values.Values;
        public void Add(string key, DynamoDBValue value) => _values.Add(key, value);
        public bool ContainsKey(string key) => _values.ContainsKey(key);
        public bool Remove(string key) => _values.Remove(key);
        public bool TryGetValue(string key, out DynamoDBValue value) => _values.TryGetValue(key, out value);

        #endregion

        #region IReadOnlyDictionary<string, DynamoDBValue

        IEnumerable<string> IReadOnlyDictionary<string, DynamoDBValue>.Keys => _values.Keys;
        IEnumerable<DynamoDBValue> IReadOnlyDictionary<string, DynamoDBValue>.Values => _values.Values;

        #endregion

        #region ICollection<KeyValuePair<string, DynamoDBValue>>

        public int Count => _values.Count;
        public bool IsReadOnly => ((ICollection<KeyValuePair<string, DynamoDBValue>>)_values).IsReadOnly;
        public void Add(KeyValuePair<string, DynamoDBValue> item) => ((ICollection<KeyValuePair<string, DynamoDBValue>>)_values).Add(item);
        public void Clear() => _values.Clear();
        public bool Contains(KeyValuePair<string, DynamoDBValue> item) => ((ICollection<KeyValuePair<string, DynamoDBValue>>)_values).Contains(item);
        public void CopyTo(KeyValuePair<string, DynamoDBValue>[] array, int arrayIndex) => ((ICollection<KeyValuePair<string, DynamoDBValue>>)_values).CopyTo(array, arrayIndex);
        public bool Remove(KeyValuePair<string, DynamoDBValue> item) => ((ICollection<KeyValuePair<string, DynamoDBValue>>)_values).Remove(item);

        #endregion

        #region IEnumerable<KeyValuePair<string, DynamoDBValue>>

        public IEnumerator<KeyValuePair<string, DynamoDBValue>> GetEnumerator() => _values.GetEnumerator();

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

        #endregion
    }
}