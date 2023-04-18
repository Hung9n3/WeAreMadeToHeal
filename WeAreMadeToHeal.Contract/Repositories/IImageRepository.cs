using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<List<Image>> GetByProductAsync(string productId);
    }
}
