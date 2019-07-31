// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Index
{
    [PublicAPI]
    public interface IDynamoDBIndex : IDynamoDBIndexReadSyntax
    {
        string Name { get; }
        DynamoDBAttributePath HashKeyAttribute { get; }
        DynamoDBAttributePath RangeKeyAttribute { get; }

        IDynamoDBIndexReadSyntax UseConsistentRead();
    }
}