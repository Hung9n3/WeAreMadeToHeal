using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class LogicContext
    {
        public LogicContext(IImageLogic ImageLogic, IUserManager UserLogic, ITagLogic TagLogic, ICouponLogic CouponLogic,
            ICouponUserLogic CouponUserLogic, ICartItemLogic CartItemLogic, ICategoryLogic CategoryLogic, IOrderItemLogic OrderItemLogic,
            IProductLogic ProductLogic, IBankCardLogic BankCardLogic)
        {
            this.ProductLogic = ProductLogic;
            this.ImageLogic = ImageLogic;
            this.UserLogic = UserLogic;
            this.TagLogic = TagLogic;
            this.CouponLogic = CouponLogic;
            this.BankCardLogic = BankCardLogic;
            this.CategoryLogic = CategoryLogic;
            this.OrderItemLogic = OrderItemLogic;
            this.CartItemLogic = CartItemLogic;
            this.CouponUserLogic = CouponUserLogic;
        }

        public IImageLogic ImageLogic { get; }
        public IUserManager UserLogic { get; }
        public ITagLogic TagLogic { get; }
        public ICouponLogic CouponLogic { get; }
        public ICouponUserLogic CouponUserLogic { get; }
        public ICartItemLogic CartItemLogic { get; }
        public ICategoryLogic CategoryLogic { get; }
        public IOrderItemLogic OrderItemLogic { get; }
        public IProductLogic ProductLogic { get; }
        public IBankCardLogic BankCardLogic { get; }
    }
}
