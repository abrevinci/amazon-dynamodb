// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.BatchRead
{
    [PublicAPI]
    public interface IDynamoDBTableBatchReadTerminationSyntax : IDynamoDBTableBatchReadSyntax
    {
        IAsyncEnumerable<DynamoDBMap> GetAllAsync();
    }
}