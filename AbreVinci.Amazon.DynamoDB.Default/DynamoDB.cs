// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Default.Internal.Core;

namespace AbreVinci.Amazon.DynamoDB.Default
{
    public static class DynamoDB
    {
        public static IDynamoDB Create()
        {
            return new Internal.DynamoDB(new DynamoDBClient());
        }

        public static IDynamoDB Create(IDynamoDBClient client)
        {
            return new Internal.DynamoDB(client);
        }
    }
}