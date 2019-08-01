// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

namespace AbreVinci.Amazon.DynamoDB.Mock
{
    public static class MockDynamoDB
    {
        public static IMockDynamoDB Create()
        {
            return new Internal.DynamoDB();
        }
    }
}