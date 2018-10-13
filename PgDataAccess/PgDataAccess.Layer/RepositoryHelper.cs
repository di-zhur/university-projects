using System;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;

namespace PgDataAccess.Layer
{
    internal static class RepositoryHelper
    {

        public static T GetEntity<T>(this NpgsqlDataReader dr) where T : class
        {
            var props = typeof(T).GetProperties();
            var instance = Activator.CreateInstance(typeof(T));
            foreach (var prop in props)
            {
                dynamic value = Convert.ChangeType(dr[prop.Name], prop.PropertyType);
                prop.SetValue(instance, value);
            }

            return (T) instance;
        }

        public static void ParametesAddWithValue(this NpgsqlCommand cmd, object values)
        {
            var props = values.GetType().GetProperties();
            foreach (var prop in props)
            {
                var value = Convert.ChangeType(prop.GetValue(values), prop.PropertyType);
                var strParameters = $"@{prop.Name}";
                cmd.Parameters.AddWithValue(strParameters, value);
            }
        }

        public static string GetFieldsQuery<T>() where T : class
        {
            var props = typeof(T).GetProperties();
            string fields = null;
            for (int i = 0; i < props.Length; i++)
                fields += i == props.Length - 1 ? $"\"{props[i].Name}\"" : $"\"{props[i].Name}\", ";

            return fields;
        }

        public static string GetValuesQueryInsert<T>() where T : class
        {
            var props = typeof(T).GetProperties();
            string fields = null;
            for (int i = 0; i < props.Length; i++)
                fields += i == props.Length - 1 ? $"@{props[i].Name}" : $"@{props[i].Name}, ";

            return fields;
        }

        public static void SetValuesBinaryImporter<T>(this NpgsqlBinaryImporter importer, IEnumerable<T> o) where T : class
        {
            foreach (var entity in o)
            {
                importer.StartRow();
                var props = entity.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var type = GetNpgsqlDbType(prop.PropertyType);
                    importer.Write(prop, type);
                }
            }
        }

        public static string GetValuesQueryUpdate<T>() where T : class
        {
            var props = typeof(T).GetProperties();
            string fields = null;
            for (int i = 0; i < props.Length; i++)
                fields += i == props.Length - 1
                    ? $"\"{props[i].Name}\" = @{props[i].Name}"
                    : $"\"{props[i].Name}\" = @{props[i].Name}, ";
            
            return fields;
        }

        public static NpgsqlDbType GetNpgsqlDbType(Type type)
        {
            if (type == typeof(Guid))
                return NpgsqlDbType.Uuid;
            if (type == typeof (Array))
                return NpgsqlDbType.Array;
            if (type== typeof(string))
                return NpgsqlDbType.Text;
            if (type == typeof(int))
                return NpgsqlDbType.Integer;
            if (type == typeof(double))
                return NpgsqlDbType.Double;
            if (type == typeof(DateTime))
                return NpgsqlDbType.Date;
            if (type == typeof(float))
                return NpgsqlDbType.Real;
            if (type == typeof(bool))
                return NpgsqlDbType.Boolean;
            if (type == typeof(long))
                return NpgsqlDbType.Bigint;
            if (type == typeof(char))
                return NpgsqlDbType.Char;

            return new NpgsqlDbType();
        }
    }
}
