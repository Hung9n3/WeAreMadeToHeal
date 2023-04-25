using System.ComponentModel;
using System.Data;

namespace WeAreMadeToHeal.Helpers
{
    public static class EntityHelpers
    {
        public static List<T> GetEntityFromDataTable<T>(this DataTable table) where T : BaseEntity
        {
            Type type = typeof(T);
            var rows = table.Rows;
            var columns = table.Columns;
            var list = new List<T>();
            var properties = type.GetProperties();
            var entity = (T)Activator.CreateInstance(type, new object[] {});
            foreach(DataRow row in rows)
            {
                foreach(var property in properties) 
                {
                    if (columns.Contains(property.Name))
                    {
                        var converter = TypeDescriptor.GetConverter(property.PropertyType);
                        var value = converter.ConvertFromString(row[property.Name].ToString());
                        property.SetValue(entity, value);
                    }
                }
                list.Add(entity);
            }
            return list;
        }
    }
}
