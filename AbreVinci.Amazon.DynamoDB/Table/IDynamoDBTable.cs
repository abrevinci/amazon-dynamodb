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

        IDynamoDBTableReadSyntax UseConsistentRead();

        IDynamoDBTableConditionalWriteSyntax If(DynamoDBPredicateExpression predicateExpression);
        
        IDynamoDBTableTransactionalReadSyntax TransactionalRead();
        IDynamoDBTableTransactionalWriteSyntax TransactionalWrite();
    }
}
