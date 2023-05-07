using Dawn;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class ProductLogic : BaseLogic<Product, IProductRepository>, IProductLogic
{
    public ProductLogic(IProductRepository dataProvider) : base(dataProvider)
    {
       
    }

    #region [Custom Method Return Single]
    #endregion

    #region [Custom Method Return List]
    public Task<List<Product>> GetByCategory(string cateId)
    {
        Guard.Argument(cateId, nameof(cateId));
        var result = _dataProvider.GetByCategory(cateId);
        return result;
    }

    public Task<List<Product>> GetByColor(string color)
    {
        Guard.Argument(color, nameof(color));
        var result = _dataProvider.GetByColor(color);
        return result;
    }

    public Task<List<Product>> GetBySize(string size)
    {
        Guard.Argument(size, nameof(size));
        var result = _dataProvider.GetBySize(size);
        return result;
    }

    public Task<List<Product>> GetByTag(string tagId)
    {
        Guard.Argument(tagId, nameof(tagId));
        var result = _dataProvider.GetByTag(tagId);
        return result;
    }

    public Task UpdateAmountByOrder(Order order)
    {
        Guard.Argument(order, nameof(order));
        Guard.Argument(order.OrderItems, nameof(order.OrderItems));

        var result = _dataProvider.UpdateAmountByOrder(order);
        return result;
    }
    #endregion
}
