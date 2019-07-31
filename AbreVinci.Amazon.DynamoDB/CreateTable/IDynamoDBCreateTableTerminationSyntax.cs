// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.CreateTable
{
    [PublicAPI]
    public interface IDynamoDBCreateTableTerminationSyntax
    {
        Task<DynamoDBTableDescription> ExecuteAsync(bool waitForCompletion = false);
    }
}