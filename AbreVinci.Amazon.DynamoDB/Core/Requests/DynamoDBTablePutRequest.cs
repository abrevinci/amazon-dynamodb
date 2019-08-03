// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Core.Requests
{
    /// <summary>
    /// Describes a put request in terms of library abstractions and is the input to <see cref="IDynamoDBClient.PutAsync"/>.
    /// </summary>
    [PublicAPI]
    public class DynamoDBTablePutRequest
    {
        public DynamoDBTablePutRequest(string tableName, DynamoDBMap item, bool returnOldItem)
        {
            TableName = tableName;
            Item = item;
            ReturnOldItem = returnOldItem;
        }
        
        public string TableName { get; }
        public DynamoDBMap Item { get; }
        public bool ReturnOldItem { get; }
    }
}