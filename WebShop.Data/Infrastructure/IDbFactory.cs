using System;

namespace WebShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        WebShopDbContext Init();
    }
}