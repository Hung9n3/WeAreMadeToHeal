using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class CouponLogic : BaseLogic<Coupon, ICouponRepository>, ICouponLogic
{
    public CouponLogic(ICouponRepository dataProvider) : base(dataProvider)
    {
        
    }

    public Task<List<Coupon>> GetByUserAsync(string userId)
    {
        Guard.Argument(userId, nameof(userId));
        var result = _dataProvider.GetByUserAsync(userId);
        return result;
    }
    #region [Custom Method Return Single]
    #endregion

    #region [Custom Method Return List]
    #endregion
}
