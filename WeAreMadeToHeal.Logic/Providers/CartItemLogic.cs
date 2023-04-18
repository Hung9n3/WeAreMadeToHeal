using Dawn;
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
    #region [Custom Method Return Single]
    #endregion

    #region [Custom Method Return List]
    public async Task<List<CartItem>> GetByUserAsync(string userId)
    {
        Guard.Argument(userId, nameof(userId));
        var result = await _dataProvider.GetByUserAsync(userId);
        return result;
    }
    #endregion
}
