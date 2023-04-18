using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IProductLogic : IBaseLogicProvider<Product>
    {
        Task<List<Product>> GetByCategory(string cateId);
        Task<List<Product>> GetByTag(string tagId);
        Task<List<Product>> GetBySize(string size);
        Task<List<Product>> GetByColor(string color);
    }
}
