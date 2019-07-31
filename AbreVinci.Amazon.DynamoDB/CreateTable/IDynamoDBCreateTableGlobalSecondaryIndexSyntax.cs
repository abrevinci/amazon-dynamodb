// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableGlobalSecondaryIndexSyntax
    {
        IDynamoDBCreateTableGlobalSecondaryIndexKeySelectedSyntax WithKey<THashKey>(DynamoDBAttributePath hashKeyAttribute) where THashKey : DynamoDBKeyValue;
        IDynamoDBCreateTableGlobalSecondaryIndexKeySelectedSyntax WithKey<THashKey, TRangeKey>(DynamoDBAttributePath hashKeyAttribute, DynamoDBAttributePath rangeKeyAttribute) where THashKey : DynamoDBKeyValue where TRangeKey : DynamoDBKeyValue;
    }
}