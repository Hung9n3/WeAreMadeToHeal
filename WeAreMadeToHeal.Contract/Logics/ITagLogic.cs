using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface ITagLogic : IBaseLogicProvider<Tag>
    {
        Task<List<Tag>> GetByProduct(string productId);
    }
}
