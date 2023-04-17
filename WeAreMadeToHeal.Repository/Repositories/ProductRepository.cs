using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WRMTHDbContext context) : base(context)
        {
        }
    }
}
