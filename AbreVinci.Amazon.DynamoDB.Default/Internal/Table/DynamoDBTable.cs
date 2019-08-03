// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Default.Internal.Table.Index;
using AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition;
using AbreVinci.Amazon.DynamoDB.Expressions.Predicate;
using AbreVinci.Amazon.DynamoDB.Expressions.Update;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table;
using AbreVinci.Amazon.DynamoDB.Table.BatchRead;
using AbreVinci.Amazon.DynamoDB.Table.BatchWrite;
using AbreVinci.Amazon.DynamoDB.Table.If;
using AbreVinci.Amazon.DynamoDB.Table.Index;
using AbreVinci.Amazon.DynamoDB.Table.Query;
using AbreVinci.Amazon.DynamoDB.Table.Scan;
using AbreVinci.Amazon.DynamoDB.Table.TransactionalRead;
using AbreVinci.Amazon.DynamoDB.Table.TransactionalWrite;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Table
{
    internal class DynamoDBTable : IDynamoDBTable
    {
        #region Fields

        private readonly IDynamoDBClient _client;
        private readonly DynamoDBTableDescription _tableDescription;

        #endregion

        #region Constructor

        public DynamoDBTable(IDynamoDBClient client, DynamoDBTableDescription tableDescription)
        {
            _client = client;
            _tableDescription = tableDescription;
            Indexes = new ReadOnlyDictionary<string, IDynamoDBIndex>(
                tableDescription.Indexes.ToDictionary(
                    indexDescription => indexDescription.Name,
                    indexDescription => (IDynamoDBIndex)new DynamoDBIndex(client, this, indexDescription)));
        }

        #endregion

        #region IDynamoDBTable

        public string Name => _tableDescription.Name;
        public DynamoDBAttributePath HashKeyAttribute => _tableDescription.HashKeyAttribute;
        public DynamoDBAttributePath RangeKeyAttribute => _tableDescription.RangeKeyAttribute;
        public IReadOnlyDictionary<string, IDynamoDBIndex> Indexes { get; }

        public IDynamoDBTableReadSyntax UseConsistentRead()
        {
            return new DynamoDBTableReadContext(_client, this, true, null);
        }

        public IDynamoDBTableConditionalWriteSyntax If(DynamoDBPredicateExpression predicateExpression)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTableTransactionalReadSyntax TransactionalRead()
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTableTransactionalWriteSyntax TransactionalWrite()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDynamoDBTableReadSyntax

        public IDynamoDBTableReadSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes)
        {
            return new DynamoDBTableReadContext(_client, this, false, attributes);
        }

        public IDynamoDBTableReadSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes)
        {
            return new DynamoDBTableReadContext(_client, this, false, attributes);
        }

        public Task<DynamoDBMap> GetAsync(DynamoDBKeyValue hashKey)
        {
            return new DynamoDBTableReadContext(_client, this, false, null).GetAsync(hashKey);
        }

        public Task<DynamoDBMap> GetAsync(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey)
        {
            return new DynamoDBTableReadContext(_client, this, false, null).GetAsync(hashKey, rangeKey);
        }

        public IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue hashKey)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue hashKey, DynamoDBKeyConditionExpression keyConditionExpression)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTableScanSyntax Scan()
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTableBatchReadSyntax BatchRead()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDynamoDBTableWriteSyntax

        public Task<DynamoDBMap> PutAsync(DynamoDBMap item, bool returnOldItem = false)
        {
            return new DynamoDBTableWriteContext(_client, this).PutAsync(item, returnOldItem);
        }

        public Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue hashKey, bool returnDeletedItem = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey, bool returnDeletedItem = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue hashKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None)
        {
            throw new System.NotImplementedException();
        }

        public Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue hashKey, DynamoDBKeyValue rangeKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTableBatchWriteSyntax BatchWrite()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}