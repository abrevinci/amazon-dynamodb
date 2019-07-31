// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBTableDescription
    {
        public string Name { get; }
        public DynamoDBAttributePath HashKeyAttribute { get; }
        public DynamoDBAttributePath RangeKeyAttribute { get; }
        public IEnumerable<DynamoDBIndexDescription> Indexes { get; }
    }
}