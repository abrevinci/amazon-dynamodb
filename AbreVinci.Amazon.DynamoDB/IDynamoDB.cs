// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
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
        
        /// <summary>
        /// Access a table interface using an already known description.
        /// </summary>
        /// <remarks>
        /// A table description might be retrieved by calling <see cref="DescribeTableAsync(string)"/>
        /// </remarks>
        /// <param name="tableDescription">The table description describing the table's name, keys and indexes.</param>
        /// <returns>A table interface which can be used to perform per-table operations.</returns>
        /// <example>
        /// <code>
        /// var tableDescription = new DynamoDBTableDescription("MyTable", "id);
        /// var table = dynamoDB.AccessTable(tableDescription);
        /// </code>
        /// </example>
        IDynamoDBTable AccessTable(DynamoDBTableDescription tableDescription);

        IDynamoDBCreateTableSyntax CreateTable(string tableName);
        Task DeleteTableAsync(string tableName, bool waitForCompletion = false);

        IDynamoDBReadSyntax UseConsistentRead(params IDynamoDBTable[] tables);
        IDynamoDBReadSyntax UseConsistentRead(IEnumerable<IDynamoDBTable> tables);

        IDynamoDBTransactionalReadSyntax TransactionalRead();
        IDynamoDBTransactionalWriteSyntax TransactionalWrite();
    }
}