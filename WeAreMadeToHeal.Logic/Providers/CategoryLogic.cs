using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class CategoryLogic : BaseLogic<Category, ICategoryRepository>, ICategoryLogic
{
    public CategoryLogic(ICategoryRepository dataProvider) : base(dataProvider)
    {
        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        #endregion
    }
}
