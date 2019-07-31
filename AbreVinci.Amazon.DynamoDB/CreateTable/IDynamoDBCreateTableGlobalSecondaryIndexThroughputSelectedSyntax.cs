// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableGlobalSecondaryIndexThroughputSelectedSyntax
    {
        IDynamoDBCreateTableThroughputSelectedSyntax WithKeyProjection();
        IDynamoDBCreateTableThroughputSelectedSyntax WithFullProjection();
        IDynamoDBCreateTableThroughputSelectedSyntax WithProjection(IEnumerable<DynamoDBAttributePath> nonKeyAttributes);
    }
}