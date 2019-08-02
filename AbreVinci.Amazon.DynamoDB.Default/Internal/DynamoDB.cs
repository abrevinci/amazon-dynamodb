// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.BatchRead;
using AbreVinci.Amazon.DynamoDB.BatchWrite;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.CreateTable;
using AbreVinci.Amazon.DynamoDB.Default.Internal.Table;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Table;
using AbreVinci.Amazon.DynamoDB.TransactionalRead;
using AbreVinci.Amazon.DynamoDB.TransactionalWrite;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal
{
    internal class DynamoDB : IDynamoDB
    {
        #region Fields

        private readonly IDynamoDBClient _client;

        #endregion

        #region Constructor

        public DynamoDB(IDynamoDBClient client)
        {
            _client = client;
        }

        #endregion

        #region IDynamoDB

        public Task<DynamoDBTableDescription> DescribeTableAsync(string tableName)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTable AccessTable(DynamoDBTableDescription tableDescription)
        {
            return new DynamoDBTable(_client, tableDescription);
        }

        public IDynamoDBCreateTableSyntax CreateTable(string tableName)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTableAsync(string tableName, bool waitForCompletion = false)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBReadSyntax UseConsistentRead(params IDynamoDBTable[] tables)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBReadSyntax UseConsistentRead(IEnumerable<IDynamoDBTable> tables)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTransactionalReadSyntax TransactionalRead()
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTransactionalWriteSyntax TransactionalWrite()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDynamoDBReadSyntax

        public IDynamoDBBatchReadSyntax BatchRead()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDynamoDBWriteSyntax

        public IDynamoDBBatchWriteSyntax BatchWrite()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}