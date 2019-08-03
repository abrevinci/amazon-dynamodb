// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableSyntax
    {
        IDynamoDBCreateTableKeySelectedSyntax WithKey<TPartitionKey>(DynamoDBAttributePath partitionKeyAttribute) where TPartitionKey : DynamoDBKeyValue;
        IDynamoDBCreateTableKeySelectedSyntax WithKey<TPartitionKey, TSortKey>(DynamoDBAttributePath partitionKeyAttribute, DynamoDBAttributePath sortKeyAttribute) where TPartitionKey : DynamoDBKeyValue where TSortKey : DynamoDBKeyValue;
    }
}