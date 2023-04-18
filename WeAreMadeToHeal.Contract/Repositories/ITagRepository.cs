using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<List<Tag>> GetByProduct(string productId);
    }
}
