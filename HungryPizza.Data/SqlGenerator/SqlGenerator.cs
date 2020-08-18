using HungryPizza.Data.Enums;
using HungryPizza.Data.Sqlite;
using HungryPizza.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace HungryPizza.Data.SqlGenerator
{
    public class SqlGenerator<TEntity, TKey> : ISqlGenerator<TEntity, TKey> where TEntity : class
    {
        private string _table;

        public string Table
        {
            get => _table ??= typeof(TEntity).GetCustomAttribute<TableAttribute>(false)?.Name ?? typeof(TEntity).Name;
        }

        private IEnumerable<(PropertyInfo, string)> _columns;

        private IEnumerable<(PropertyInfo Property, string Name)> Columns
        {
            get => _columns ??= typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                .Where(p => p.GetCustomAttribute<NotMappedAttribute>(false) == null && !p.PropertyType.IsGenericType && !typeof(Entity).IsAssignableFrom(p.PropertyType))
                .Select(p => (p, p.GetCustomAttribute<ColumnAttribute>(false)?.Name ?? p.Name));
        }

        private string GetColumnSql(PropertyInfo property, string name)
        {
            var mapping = GetDataType(property.PropertyType, out bool isNullable);
            var dataType = mapping.GetSqliteTypeName();

            var sql = string.Format("\"{0}\" {1}", name, dataType);

            if (name == "Id")
            {
                sql = string.Concat(sql, " PRIMARY KEY");

                if (mapping.SqliteType == SqliteDataType.Integer)
                {
                    sql = string.Concat(sql, " AUTOINCREMENT");
                }
            }
            else
            {
                sql = string.Concat(sql, isNullable ? " NULL" : " NOT NULL");

                if (property.Name.EndsWith("Id") && property.PropertyType.Equals(typeof(TKey)))
                {
                    var foreignKeyTable = property.Name[0..^2];
                    sql = string.Concat(sql, $" REFERENCES \"{foreignKeyTable}\"(\"Id\")");
                }
            }

            return sql;
        }

        private SqliteDataTypeMapping GetDataType(Type type, out bool isNullable)
        {
            var mappings = SqliteDataTypeMapper.GetDataTypeMappings();
            var underlyingType = Nullable.GetUnderlyingType(type);

            if (underlyingType != null)
            {
                type = underlyingType;
            }

            isNullable = underlyingType != null || (type.GetCustomAttribute<RequiredAttribute>(false) == null && type == typeof(string));

            return mappings.First(m => m.ClrType.Equals(type));
        }

        public string CreateTable()
        {
            var columns = string.Join($", {Environment.NewLine}\t", Columns.Select(c => GetColumnSql(c.Property, c.Name)));
            return string.Format("{0}{1}{2}{1}{3}{4}{1}{5}", $"CREATE TABLE IF NOT EXISTS \"{Table}\"", Environment.NewLine, "(", "\t", columns, ")");
        }

        public string Insert()
        {
            var columnsExceptId = Columns.Where(c => c.Name != "Id");

            var columns = string.Join(", ", columnsExceptId.Select(c => $"\"{c.Name}\""));
            var values = string.Join(", ", columnsExceptId.Select(c => $"@{c.Name}"));
            return $"INSERT INTO \"{Table}\" ({columns}) VALUES ({values})";
        }

        public string Select() => $"SELECT * FROM \"{Table}\"";

        public string Select(TKey id) => $"SELECT * FROM \"{Table}\" WHERE \"Id\" = @Id";

        public string Update()
        {
            var columnsExceptId = Columns.Where(c => c.Name != "Id");

            var columns = string.Join(", ", columnsExceptId.Select(c => $"\"{c.Name}\" = @{c.Name}"));
            return $"UPDATE \"{Table}\" SET {columns} WHERE \"Id\" = @Id";
        }

        public string Delete() => $"DELETE FROM \"{Table}\" WHERE \"Id\" = @Id";
    }
}
