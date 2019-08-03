// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Index
{
    [PublicAPI]
    public interface IDynamoDBIndex : IDynamoDBIndexReadSyntax
    {
        string Name { get; }
        DynamoDBAttributePath PartitionKeyAttribute { get; }
        DynamoDBAttributePath SortKeyAttribute { get; }

        IDynamoDBIndexReadSyntax UseConsistentRead();
    }
}