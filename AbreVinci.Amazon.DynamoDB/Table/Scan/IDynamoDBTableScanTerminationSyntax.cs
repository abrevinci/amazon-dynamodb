// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Scan
{
    [PublicAPI]
    public interface IDynamoDBTableScanTerminationSyntax
    {
        IAsyncEnumerable<DynamoDBMap> GetAllAsync();
        Task<int> CountAsync();
    }
}