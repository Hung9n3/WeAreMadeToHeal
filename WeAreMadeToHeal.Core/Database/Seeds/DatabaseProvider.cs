using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class DatabaseProvider
{
    private readonly WRMTHDbContext _context;
    public DatabaseProvider(WRMTHDbContext context)
    {
        _context = context;
    }

    public async Task SeedData()
    {
       await _context.Users.AddRangeAsync(SeedProvider.Current.Users);
       await _context.Coupons.AddRangeAsync(SeedProvider.Current.Coupons);
       await _context.Tags.AddRangeAsync(SeedProvider.Current.Tags);
       await _context.Categories.AddRangeAsync(SeedProvider.Current.Categories);
       await _context.BankCards.AddRangeAsync(SeedProvider.Current.BankCards);
       await _context.Orders.AddRangeAsync(SeedProvider.Current.Orders);
       await _context.OrderItems.AddRangeAsync(SeedProvider.Current.OrderItems);
       await _context.CartItems.AddRangeAsync(SeedProvider.Current.CartItems);
       await _context.CouponUsers.AddRangeAsync(SeedProvider.Current.CouponUsers);
       await _context.Images.AddRangeAsync(SeedProvider.Current.Images);
       await _context.Products.AddRangeAsync(SeedProvider.Current.Products);
       await _context.TagProducts.AddRangeAsync(SeedProvider.Current.TagProducts);
       await _context.SaveChangesAsync();
    }

    public async Task CleanSeed()
    {
        _context.Users.RemoveRange(await _context.Users.ToListAsync());
        _context.Coupons.RemoveRange(await _context.Coupons.ToListAsync());
        _context.Tags.RemoveRange(await _context.Tags.ToListAsync());
        _context.Categories.RemoveRange(await _context.Categories.ToListAsync());
        _context.BankCards.RemoveRange(await _context.BankCards.ToListAsync());
        _context.Orders.RemoveRange(await _context.Orders.ToListAsync());
        _context.OrderItems.RemoveRange(await _context.OrderItems.ToListAsync());
        _context.CartItems.RemoveRange(await _context.CartItems.ToListAsync());
        _context.CouponUsers.RemoveRange(await _context.CouponUsers.ToListAsync());
        _context.Images.RemoveRange(await _context.Images.ToListAsync());
        _context.Products.RemoveRange(await _context.Products.ToListAsync());
        _context.TagProducts.RemoveRange(await _context.TagProducts.ToListAsync());
        await _context.SaveChangesAsync();
    }
}
