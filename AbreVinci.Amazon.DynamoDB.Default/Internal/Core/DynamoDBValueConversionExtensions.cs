// Copyright (C) 2019 AbreVinci Digital AB - All Rights Reserved

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AbreVinci.Amazon.DynamoDB.Model.Values;
using Amazon.DynamoDBv2.Model;

namespace AbreVinci.Amazon.DynamoDB.Default.Internal.Core
{
    internal static class DynamoDBValueConversionExtensions
    {
        public static AttributeValue ToAwsValue(this DynamoDBValue value)
        {
            switch (value)
            {
                case DynamoDBString s:
                    return new AttributeValue {S = s};
                case DynamoDBNumber n:
                    return new AttributeValue {N = n.InternalValue};
                case DynamoDBBoolean b:
                    return new AttributeValue {BOOL = b, IsBOOLSet = true};
                case DynamoDBBinary b:
                    return new AttributeValue {B = b.ToAwsBinary()};
                case DynamoDBMap m:
                    return new AttributeValue {M = m.ToAwsDictionary(), IsMSet = true};
                case DynamoDBList l:
                    return new AttributeValue {L = l.ToAwsList(), IsLSet = true};
                case DynamoDBSet<DynamoDBString> ss:
                    return new AttributeValue {SS = ss.ToAwsSet()};
                case DynamoDBSet<DynamoDBNumber> ns:
                    return new AttributeValue {NS = ns.ToAwsSet()};
                case DynamoDBSet<DynamoDBBinary> bs:
                    return new AttributeValue {BS = bs.ToAwsSet()};
                case null:
                    return new AttributeValue {NULL = true};
            }

            throw new NotSupportedException();
        }

        private static DynamoDBValue ToValue(this AttributeValue value)
        {
            if (value.S != null)
                return new DynamoDBString(value.S);
            if (value.N != null)
                return new DynamoDBNumber(value.N);
            if (value.IsBOOLSet)
                return value.BOOL ? DynamoDBBoolean.True : DynamoDBBoolean.False;
            if (value.B != null)
                return new DynamoDBBinary(value.B.ToArray());
            if (value.IsMSet)
                return value.M.ToMap();
            if (value.IsLSet)
                return value.L.ToList();
            if (value.SS != null)
                return new DynamoDBSet<DynamoDBString>(value.SS.Select(s => (DynamoDBString)s));
            if (value.NS != null)
                return new DynamoDBSet<DynamoDBNumber>(value.NS.Select(n => new DynamoDBNumber(n)));
            if (value.BS != null)
                return new DynamoDBSet<DynamoDBBinary>(value.BS.Select(b => new DynamoDBBinary(b.ToArray())));
            if (value.NULL)
                return null;

            throw new NotSupportedException();
        }

        private static MemoryStream ToAwsBinary(this DynamoDBBinary value)
        {
            return new MemoryStream(value.AsByteArray());
        }

        public static Dictionary<string, AttributeValue> ToAwsDictionary(this DynamoDBMap value)
        {
            return value.ToDictionary(e => e.Key, e => e.Value.ToAwsValue());
        }

        private static List<AttributeValue> ToAwsList(this DynamoDBList value)
        {
            return value.Select(v => v.ToAwsValue()).ToList();
        }

        private static List<string> ToAwsSet(this DynamoDBSet<DynamoDBString> value)
        {
            return value.Select(v => v.AsString()).ToList();
        }

        private static List<string> ToAwsSet(this DynamoDBSet<DynamoDBNumber> value)
        {
            return value.Select(v => v.InternalValue).ToList();
        }

        private static List<MemoryStream> ToAwsSet(this DynamoDBSet<DynamoDBBinary> value)
        {
            return value.Select(v => v.ToAwsBinary()).ToList();
        }

        public static DynamoDBMap ToMap(this Dictionary<string, AttributeValue> value)
        {
            return new DynamoDBMap(value.ToDictionary(e => e.Key, e => e.Value.ToValue()));
        }

        private static DynamoDBList ToList(this List<AttributeValue> value)
        {
            return new DynamoDBList(value.Select(v => v.ToValue()));
        }
    }
}