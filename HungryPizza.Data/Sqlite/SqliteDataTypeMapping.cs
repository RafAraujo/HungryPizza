using HungryPizza.Data.Enums;
using System;

namespace HungryPizza.Data.Sqlite
{
    public class SqliteDataTypeMapping
    {
        public Type ClrType { get; set; }

        public SqliteDataType SqliteType { get; set; }

        public SqliteDataTypeMapping(Type clrType, SqliteDataType sqliteType)
        {
            ClrType = clrType;
            SqliteType = sqliteType;
        }

        public string GetSqliteTypeName() => Enum.GetName(typeof(SqliteDataType), SqliteType).ToUpperInvariant();
    }
}
