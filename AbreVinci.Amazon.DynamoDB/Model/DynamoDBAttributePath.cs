// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public class DynamoDBAttributePath
    {
        public DynamoDBAttributePath(string path)
        {
            Path = path.Split('.');
        }
        
        public IReadOnlyList<string> Path { get; }

        public static implicit operator DynamoDBAttributePath(string path)
        {
            return new DynamoDBAttributePath(path);
        }

        public override string ToString()
        {
            return string.Join(".", Path);
        }
    }
}