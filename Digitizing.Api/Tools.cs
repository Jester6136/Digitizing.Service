using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Digitizing.Api
{
    public class Tools
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (pro.PropertyType == typeof(Guid))
                        {
                            var val = !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? Guid.Parse(dr[column.ColumnName].ToString()) : dr[column.ColumnName];
                            pro.SetValue(obj, (val == DBNull.Value) ? null : val, null);
                        }
                        else if (pro.PropertyType == typeof(Nullable<Guid>))
                        {
                            var val = !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? Guid.Parse(dr[column.ColumnName].ToString()) : dr[column.ColumnName];
                            pro.SetValue(obj, (val == DBNull.Value) ? null : val, null);
                        }
                        else if (pro.PropertyType == typeof(Int32))
                        {
                            var val = !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? Int32.Parse(dr[column.ColumnName].ToString()) : dr[column.ColumnName];
                            pro.SetValue(obj, (val == DBNull.Value) ? null : val, null);
                        }
                        else if (pro.PropertyType == typeof(Nullable<Int32>))
                        {
                            var val = !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? Int32.Parse(dr[column.ColumnName].ToString()) : dr[column.ColumnName];
                            pro.SetValue(obj, (val == DBNull.Value) ? null : val, null);
                        }
                        else if (pro.PropertyType == typeof(DateTime))
                        {
                            var val = !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? DateTime.ParseExact(dr[column.ColumnName].ToString(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) : dr[column.ColumnName];
                            pro.SetValue(obj, (val == DBNull.Value) ? null : val, null);
                        }
                        else if (pro.PropertyType == typeof(Nullable<DateTime>))
                        {

                            var val = !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? DateTime.ParseExact(dr[column.ColumnName].ToString(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) : dr[column.ColumnName];
                            pro.SetValue(obj, (val == DBNull.Value) ? null : val, null);
                        }
                        else
                        {
                            var val = dr[column.ColumnName];
                            pro.SetValue(obj, (val == DBNull.Value) ? null : val, null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
