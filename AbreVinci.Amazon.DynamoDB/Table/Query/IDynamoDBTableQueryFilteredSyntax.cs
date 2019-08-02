// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Query
{
    [PublicAPI]
    public interface IDynamoDBTableQueryFilteredSyntax : IDynamoDBTableQueryTerminationSyntax
    {
        IDynamoDBTableQueryFilteredSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        IDynamoDBTableQueryFilteredSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes);
    }
}