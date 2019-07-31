// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Table.If
{
    [PublicAPI]
    public class Out<T>
    {
        public T Value { get; set; }
    }
}