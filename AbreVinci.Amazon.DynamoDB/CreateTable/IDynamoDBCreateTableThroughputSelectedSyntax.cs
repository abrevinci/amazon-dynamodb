// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableThroughputSelectedSyntax : IDynamoDBCreateTableTerminationSyntax
    {
        IDynamoDBCreateTableGlobalSecondaryIndexSyntax WithGlobalSecondaryIndex(string indexName);
        IDynamoDBCreateTableLocalSecondaryIndexSyntax WithLocalSecondaryIndex(string indexName);
    }
}