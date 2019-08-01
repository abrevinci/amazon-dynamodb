// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table.Index;
using AbreVinci.Amazon.DynamoDB.Table.Index.Query;

namespace AbreVinci.Amazon.DynamoDB.Mock.Internal.Table.Index
{
    internal class DynamoDBIndex : IDynamoDBIndex
    {
        private readonly DynamoDBTable _table;
        private readonly DynamoDBIndexDescription _indexDescription;

        public DynamoDBIndex(DynamoDBTable table, DynamoDBIndexDescription indexDescription)
        {
            _table = table;
            _indexDescription = indexDescription;
        }

        public string Name => _indexDescription.Name;
        public DynamoDBAttributePath HashKeyAttribute => _indexDescription.HashKeyAttribute;
        public DynamoDBAttributePath RangeKeyAttribute => _indexDescription.RangeKeyAttribute;
        
        public IDynamoDBIndexReadSyntax UseConsistentRead()
        {
            throw new System.NotImplementedException();
        }
        
        public IDynamoDBIndexQuerySyntax Query(DynamoDBKeyValue hashKey)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBIndexQuerySyntax Query(DynamoDBKeyValue hashKey, DynamoDBKeyConditionExpression keyConditionExpression)
        {
            throw new System.NotImplementedException();
        }
    }
}