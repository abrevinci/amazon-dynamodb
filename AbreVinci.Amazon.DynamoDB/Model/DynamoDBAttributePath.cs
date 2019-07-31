// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBAttributePath
    {
        public IReadOnlyList<string> Path { get; }
    }
}