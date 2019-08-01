// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;

namespace AbreVinci.Amazon.DynamoDB.Mock
{
    public interface IMockDynamoDB : IDynamoDB
    {
        new IMockDynamoDBTable AccessTable(DynamoDBTableDescription tableDescription);
    }
}