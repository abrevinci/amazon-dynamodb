// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.BatchRead;
using AbreVinci.Amazon.DynamoDB.BatchWrite;
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
        public IDynamoDBBatchReadSyntax BatchRead()
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBBatchWriteSyntax BatchWrite()
        {
            throw new System.NotImplementedException();
        }

        public Task<DynamoDBTableDescription> DescribeTableAsync(string tableName)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTable AccessTable(DynamoDBTableDescription tableDescription)
        {
            return new DynamoDBTable(tableDescription);
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

        public IDynamoDBTransactionalReadSyntax TransactionalRead()
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBTransactionalWriteSyntax TransactionalWrite()
        {
            throw new System.NotImplementedException();
        }
    }
}