// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.BatchWrite
{
    [PublicAPI]
    public interface IDynamoDBTableBatchWriteTerminationSyntax : IDynamoDBTableBatchWriteSyntax
    {
        Task ExecuteAsync();
    }
}