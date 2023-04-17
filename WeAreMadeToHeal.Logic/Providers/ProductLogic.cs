using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class ProductLogic : BaseLogic<Product, IProductRepository>, IProductLogic
{
    public ProductLogic(IProductRepository dataProvider) : base(dataProvider)
    {
    }
}
