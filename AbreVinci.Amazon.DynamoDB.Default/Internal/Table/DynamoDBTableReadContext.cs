// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table;
using AbreVinci.Amazon.DynamoDB.Table.BatchRead;
using AbreVinci.Amazon.DynamoDB.Table.Query;
using AbreVinci.Amazon.DynamoDB.Table.Scan;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Table
{
    internal class DynamoDBTableReadContext : IDynamoDBTableReadSyntax
    {
        #region Fields

        private readonly IDynamoDBClient _client;
        private readonly DynamoDBTable _table;
        private readonly bool _useConsistentRead;
        private readonly IEnumerable<DynamoDBAttributePath> _projection;

        #endregion

        #region Constructor

        public DynamoDBTableReadContext(IDynamoDBClient client, DynamoDBTable table, bool useConsistentRead, IEnumerable<DynamoDBAttributePath> projection)
        {
            _client = client;
            _table = table;
            _useConsistentRead = useConsistentRead;
            _projection = projection;
        }

        #endregion

        #region IDynamoDBTableReadSyntax

        public IDynamoDBTableReadSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes)
        {
            var newProjection = _projection?.Concat(attributes) ?? attributes;
            return new DynamoDBTableReadContext(_client, _table, _useConsistentRead, newProjection);
        }

        public IDynamoDBTableReadSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes)
        {
            var newProjection = _projection?.Concat(attributes) ?? attributes;
            return new DynamoDBTableReadContext(_client, _table, _useConsistentRead, newProjection);
        }

        public Task<DynamoDBMap> GetAsync(DynamoDBKeyValue partitionKey)
        {
            var request = new DynamoDBTableGetRequest(_table.Name, _table.PartitionKeyAttribute, partitionKey, _useConsistentRead, _projection);
            return _client.GetAsync(request);
        }

        public Task<DynamoDBMap> GetAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey)
        {
            var request = new DynamoDBTableGetRequest(_table.Name, _table.PartitionKeyAttribute, partitionKey, _table.SortKeyAttribute, sortKey, _useConsistentRead, _projection);
            return _client.GetAsync(request);
        }

        public IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue partitionKey)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTableQuerySyntax Query(DynamoDBKeyValue partitionKey, DynamoDBKeyConditionExpression keyConditionExpression)
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
    }
}