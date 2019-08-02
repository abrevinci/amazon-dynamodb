// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Core;
using AbreVinci.Amazon.DynamoDB.Expressions.KeyCondition;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using AbreVinci.Amazon.DynamoDB.Table.Index;
using AbreVinci.Amazon.DynamoDB.Table.Index.Query;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Table.Index
{
    internal class DynamoDBIndex : IDynamoDBIndex
    {
        #region Fields
        
        private readonly IDynamoDBClient _client;
        private readonly DynamoDBTable _table;
        private readonly DynamoDBIndexDescription _indexDescription;
        
        #endregion
        
        #region Constructor

        public DynamoDBIndex(IDynamoDBClient client, DynamoDBTable table, DynamoDBIndexDescription indexDescription)
        {
            _client = client;
            _table = table;
            _indexDescription = indexDescription;
        }
        
        #endregion

        #region IDynamoDBIndex
        
        public string Name => _indexDescription.Name;
        public DynamoDBAttributePath HashKeyAttribute => _indexDescription.HashKeyAttribute;
        public DynamoDBAttributePath RangeKeyAttribute => _indexDescription.RangeKeyAttribute;
        
        public IDynamoDBIndexReadSyntax UseConsistentRead()
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
        
        #region IDynamoDBIndexReadSyntax

        public IDynamoDBIndexReadSyntax IncludeAttributes(params DynamoDBAttributePath[] attributes)
        {
            throw new System.NotImplementedException();
        }

        public IDynamoDBIndexReadSyntax IncludeAttributes(IEnumerable<DynamoDBAttributePath> attributes)
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
        
        #endregion
    }
}