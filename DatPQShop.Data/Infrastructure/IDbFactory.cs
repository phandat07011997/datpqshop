using System;

namespace DatPQShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DatPQShopDbContext Init();
    }
}