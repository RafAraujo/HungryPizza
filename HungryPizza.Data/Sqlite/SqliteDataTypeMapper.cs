using HungryPizza.Data.Enums;
using System;
using System.Collections.Generic;

namespace HungryPizza.Data.Sqlite
{
    public static class SqliteDataTypeMapper
    {
        public static List<SqliteDataTypeMapping> GetDataTypeMappings()
        {
            var mappings = new List<SqliteDataTypeMapping>
            {
                new SqliteDataTypeMapping(typeof(bool), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(byte), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(byte[]), SqliteDataType.Blob),
                new SqliteDataTypeMapping(typeof(char), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(DateTime), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(DateTimeOffset), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(decimal), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(double), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(double), SqliteDataType.Real),
                new SqliteDataTypeMapping(typeof(Guid), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(short), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(int), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(long), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(sbyte), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(float), SqliteDataType.Real),
                new SqliteDataTypeMapping(typeof(string), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(TimeSpan), SqliteDataType.Text),
                new SqliteDataTypeMapping(typeof(ushort), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(uint), SqliteDataType.Integer),
                new SqliteDataTypeMapping(typeof(ulong), SqliteDataType.Integer)
            };

            return mappings;
        }
    }
}
