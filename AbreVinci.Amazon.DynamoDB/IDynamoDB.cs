// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.CreateTable;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Table;
using AbreVinci.Amazon.DynamoDB.TransactionalRead;
using AbreVinci.Amazon.DynamoDB.TransactionalWrite;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB
{
    [PublicAPI]
    public interface IDynamoDB: IDynamoDBReadSyntax, IDynamoDBWriteSyntax
    {
        Task<DynamoDBTableDescription> DescribeTableAsync(string tableName);
        IDynamoDBTable AccessTable(DynamoDBTableDescription description);

        IDynamoDBCreateTableSyntax CreateTable(string tableName);
        Task DeleteTableAsync(string tableName, bool waitForCompletion = false);

        IDynamoDBReadSyntax UseConsistentRead(params IDynamoDBTable[] tables);

        IDynamoDBTransactionalReadSyntax TransactionalRead();
        IDynamoDBTransactionalWriteSyntax TransactionalWrite();
    }
}