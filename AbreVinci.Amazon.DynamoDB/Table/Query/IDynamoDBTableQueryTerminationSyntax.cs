// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Query
{
    [PublicAPI]
    public interface IDynamoDBTableQueryTerminationSyntax
    {
        IAsyncEnumerable<DynamoDBMap> GetAllAsync();
        Task<int> CountAsync();
    }
}