// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

namespace AbreVinci.Amazon.DynamoDB.Default
{
    public static class DynamoDB
    {
        public static IDynamoDB Create()
        {
            return new Internal.DynamoDB();
        }
    }
}