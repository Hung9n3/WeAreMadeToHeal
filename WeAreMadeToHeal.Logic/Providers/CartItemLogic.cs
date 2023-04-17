using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class CartItemLogic : BaseLogic<CartItem, ICartItemRepository>, ICartItemLogic
{
    public CartItemLogic(ICartItemRepository dataProvider) : base(dataProvider)
    {
    }
}
