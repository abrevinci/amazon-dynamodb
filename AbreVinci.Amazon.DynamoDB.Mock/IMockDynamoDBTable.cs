// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table;

namespace AbreVinci.Amazon.DynamoDB.Mock
{
    public interface IMockDynamoDBTable : IDynamoDBTable
    {
        IEnumerable<DynamoDBMap> Items { get; }

        IMockDynamoDBTable AddItem(DynamoDBMap item, bool availableForNonConsistentRead = true);
        IMockDynamoDBTable AddItems(IEnumerable<DynamoDBMap> items, bool availableForNonConsistentRead = true);
    }
}