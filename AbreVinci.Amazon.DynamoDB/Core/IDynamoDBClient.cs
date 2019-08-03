// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Threading.Tasks;
using AbreVinci.Amazon.DynamoDB.Core.Requests;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Core
{
    [PublicAPI]
    public interface IDynamoDBClient
    {
        /// <summary>
        /// Executes the given get request.
        /// </summary>
        /// <param name="request">The request to execute.</param>
        /// <returns>An awaitable task that resolves to the retrieved item, or null if it is not found.</returns>
        Task<DynamoDBMap> GetAsync(DynamoDBTableGetRequest request);

        /// <summary>
        /// Executes the given put request.
        /// </summary>
        /// <param name="request">The request to execute.</param>
        /// <returns>An awaitable task that resolves to the old item (if any) in case that has been requested and one existed, or null otherwise.</returns>
        Task<DynamoDBMap> PutAsync(DynamoDBTablePutRequest request);
    }
}