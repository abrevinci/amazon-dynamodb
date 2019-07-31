// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Model
{
    [PublicAPI]
    public enum DynamoDBUpdateReturnValue
    {
        None,
        UpdatedOld,
        UpdatedNew,
        AllOld,
        AllNew
    }
}