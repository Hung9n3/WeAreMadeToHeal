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
}
