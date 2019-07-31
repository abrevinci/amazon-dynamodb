// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableKeySelectedSyntax
    {
        IDynamoDBCreateTableThroughputSelectedSyntax WithProvisionedThroughput(int readCapacity, int writeCapacity);
        IDynamoDBCreateTableThroughputSelectedSyntax WithOnDemandThroughput();
    }
}