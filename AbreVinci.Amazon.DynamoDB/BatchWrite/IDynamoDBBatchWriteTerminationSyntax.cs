// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.BatchWrite
{
    [PublicAPI]
    public interface IDynamoDBBatchWriteTerminationSyntax : IDynamoDBBatchWriteSyntax
    {
        Task ExecuteAsync();
    }
}