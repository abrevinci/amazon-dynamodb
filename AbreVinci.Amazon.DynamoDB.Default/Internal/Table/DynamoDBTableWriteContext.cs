// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Expressions.Update;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table;
using AbreVinci.Amazon.DynamoDB.Table.BatchWrite;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Table
{
    internal class DynamoDBTableWriteContext : IDynamoDBTableWriteSyntax
    {
        #region Fields
        
        private readonly IDynamoDBClient _client;
        private readonly DynamoDBTable _table;
        
        #endregion
        
        #region Constructor

        public DynamoDBTableWriteContext(IDynamoDBClient client, DynamoDBTable table)
        {
            _client = client;
            _table = table;
        }
        
        #endregion
        
        #region IDynamoDBTableWriteSyntax
        
        public Task<DynamoDBMap> PutAsync(DynamoDBMap item, bool returnOldItem = false)
        {
            var request = new DynamoDBTablePutRequest(_table.Name, item, returnOldItem);
            return _client.PutAsync(request);
        }

        public Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue partitionKey, bool returnDeletedItem = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<DynamoDBMap> DeleteAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey, bool returnDeletedItem = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None)
        {
            throw new System.NotImplementedException();
        }

        public Task<DynamoDBMap> UpdateAsync(DynamoDBKeyValue partitionKey, DynamoDBKeyValue sortKey, DynamoDBUpdateExpression updateExpression, DynamoDBUpdateReturnValue returnValue = DynamoDBUpdateReturnValue.None)
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