using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class BankCardLogic : BaseLogic<BankCard, IBankCardRepository>, IBankCardLogic
{
    public BankCardLogic(IBankCardRepository dataProvider) : base(dataProvider)
    {
        
    }
    #region [Custom Method Return Single]
    public Task<BankCard> GetByUserAsync(string userId)
    {
        Guard.Argument(userId, nameof(userId));
        var result = _dataProvider.GetByUserAsync(userId);
        return result;
    }
    #endregion

    #region [Custom Method Return List]
    #endregion

}
