// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Linq;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.BatchRead
{
    [PublicAPI]
    public interface IDynamoDBBatchReadTerminationSyntax : IDynamoDBBatchReadSyntax
    {
        IAsyncEnumerable<IAsyncGrouping<string, DynamoDBMap>> GetAllAsync();
    }
}