using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class RepositoryContext
    {
        public RepositoryContext(IImageRepository ImageRepository, IUserRepository UserRepository, ITagRepository TagRepository, ICouponRepository CouponRepository,
            ICouponUserRepository CouponUserRepository, ICartItemRepository CartItemRepository, ICategoryRepository CategoryRepository, IOrderItemRepository OrderItemRepository,
            IProductRepository ProductRepository, IBankCardRepository BankCardRepository)
        {
            this.ProductRepository = ProductRepository;
            this.ImageRepository = ImageRepository;
            this.UserRepository = UserRepository;
            this.TagRepository = TagRepository;
            this.CouponRepository = CouponRepository;
            this.BankCardRepository = BankCardRepository;
            this.CategoryRepository = CategoryRepository;
            this.OrderItemRepository = OrderItemRepository;
            this.CartItemRepository = CartItemRepository;
            this.CouponUserRepository = CouponUserRepository;
        }

        public IImageRepository ImageRepository { get;}
        public IUserRepository UserRepository { get;}
        public ITagRepository TagRepository { get; }
        public ICouponRepository CouponRepository { get; }
        public ICouponUserRepository CouponUserRepository { get;}
        public ICartItemRepository CartItemRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IBankCardRepository BankCardRepository { get; }
    }
}
