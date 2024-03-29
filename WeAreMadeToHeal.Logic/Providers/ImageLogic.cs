﻿using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class ImageLogic : BaseLogic<Image, IImageRepository>, IImageLogic
{
    public ImageLogic(IImageRepository dataProvider) : base(dataProvider)
    {
        
    }

    #region [Custom Method Return Single]
    #endregion

    #region [Custom Method Return List]
    public Task<List<Image>> GetByProductAsync(string productId)
    {
        Guard.Argument(productId, nameof(productId));
        var result = _dataProvider.GetByProductAsync(productId);
        return result;
    }
    #endregion

}
