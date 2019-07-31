// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.BatchWrite;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB
{
    [PublicAPI]
    public interface IDynamoDBWriteSyntax
    {
        IDynamoDBBatchWriteSyntax BatchWrite();
    }
}