// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Scan
{
    [PublicAPI]
    public interface IDynamoDBTableScanFilteredSyntax : IDynamoDBTableScanTerminationSyntax
    {
        IDynamoDBTableScanFilteredSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
    }
}