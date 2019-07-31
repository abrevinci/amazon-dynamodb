// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableGlobalSecondaryIndexKeySelectedSyntax
    {
        IDynamoDBCreateTableGlobalSecondaryIndexThroughputSelectedSyntax WithProvisionedThroughput(int readCapacity, int writeCapacity);
        IDynamoDBCreateTableGlobalSecondaryIndexThroughputSelectedSyntax WithOnDemandThroughput();
    }
}