// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System.Collections.Generic;
using AbreVinci.Amazon.DynamoDB.Model;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using JetBrains.Annotations;

namespace AbreVinci.Amazon.DynamoDB.Expressions.Update
{
    [PublicAPI]
    public interface IDynamoDBUpdateExpressionAttributeSyntax
    {
        IDynamoDBUpdateExpressionNonEmptySyntax Set(DynamoDBValue value);
        IDynamoDBUpdateExpressionNonEmptySyntax SetIfNotExists(DynamoDBValue value);
        IDynamoDBUpdateExpressionNonEmptySyntax Remove();
        
        IDynamoDBUpdateExpressionNonEmptySyntax Increment(DynamoDBNumber byValue, DynamoDBNumber initialValue = null);
        IDynamoDBUpdateExpressionNonEmptySyntax Decrement(DynamoDBNumber byValue, DynamoDBNumber initialValue = null);
        
        IDynamoDBUpdateExpressionNonEmptySyntax AppendListItem(DynamoDBValue value, DynamoDBList initialList = null);
        IDynamoDBUpdateExpressionNonEmptySyntax PrependListItem(DynamoDBValue value, DynamoDBList initialList = null);
        IDynamoDBUpdateExpressionNonEmptySyntax RemoveListItemAt(int index);

        IDynamoDBUpdateExpressionNonEmptySyntax AddSetItem<T>(T value, DynamoDBSet<T> initialSet = null) where T : DynamoDBKeyValue;
        IDynamoDBUpdateExpressionNonEmptySyntax RemoveSetItem<T>(T value);

        IDynamoDBUpdateExpressionAttributeSyntax Attr(DynamoDBAttributePath childAttribute);
        IDynamoDBUpdateExpressionNonEmptySyntax Remove(params DynamoDBAttributePath[] childAttributes);
        IDynamoDBUpdateExpressionNonEmptySyntax Remove(IEnumerable<DynamoDBAttributePath> childAttributes);
    }
}