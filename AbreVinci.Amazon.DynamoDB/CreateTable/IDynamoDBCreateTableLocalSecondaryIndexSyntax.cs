// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableLocalSecondaryIndexSyntax
    {
        IDynamoDBCreateTableLocalSecondaryIndexKeySelectedSyntax WithRangeKey<TRangeKey>(DynamoDBAttributePath rangeKeyAttribute) where TRangeKey : DynamoDBKeyValue;
    }
}