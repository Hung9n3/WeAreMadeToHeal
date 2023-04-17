using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal.Extensions
{
    public static class EntityExtensions
    {
        public static Tuple<bool,List<string>> HasNullProperty(this BaseEntity entity)
        {
            var result = new List<string>();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(entity) == null)
                {
                    result.Add($"{property.Name} is null/n");
                }
            }
            if(result.Count == 0)
            {
                return Tuple.Create(false, result);
            }
            else return Tuple.Create(true, result);
        }
    }
}
