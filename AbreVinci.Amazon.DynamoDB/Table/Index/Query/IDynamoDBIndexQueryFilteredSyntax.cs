// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.Index.Query
{
    [PublicAPI]
    public interface IDynamoDBIndexQueryFilteredSyntax : IDynamoDBIndexQueryTerminationSyntax
    {
        IDynamoDBIndexQueryFilteredSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes);
        IDynamoDBIndexQueryFilteredSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes);
    }
}