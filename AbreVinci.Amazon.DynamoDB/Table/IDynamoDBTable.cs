// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Expressions.Predicate;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Table.If;
using AbreVinci.Amazon.DynamoDB.Table.Index;
using AbreVinci.Amazon.DynamoDB.Table.TransactionalRead;
using AbreVinci.Amazon.DynamoDB.Table.TransactionalWrite;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table
{
    [PublicAPI]
    public interface IDynamoDBTable : IDynamoDBTableReadSyntax, IDynamoDBTableWriteSyntax
    {
        string Name { get; }
        DynamoDBAttributePath HashKeyAttribute { get; }
        DynamoDBAttributePath RangeKeyAttribute { get; }
        IReadOnlyDictionary<string, IDynamoDBIndex> Indexes { get; }

        /// <summary>
        /// Turns on consistent read for consecutive read operations.
        /// </summary>
        /// <returns>A continuation context that allows setting up and executing per-table non-transaction read requests (now with consistent read enabled).</returns>
        /// <example>
        /// <code>
        /// var item = await table.UseConsistentRead().GetAsync(hashKey);
        /// </code>
        /// </example>
        IDynamoDBTableReadSyntax UseConsistentRead();

        IDynamoDBTableConditionalWriteSyntax If(DynamoDBPredicateExpression predicateExpression);

        IDynamoDBTableTransactionalReadSyntax TransactionalRead();
        IDynamoDBTableTransactionalWriteSyntax TransactionalWrite();
    }
}