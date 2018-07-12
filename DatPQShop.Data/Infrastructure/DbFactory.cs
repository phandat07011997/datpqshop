namespace DatPQShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DatPQShopDbContext dbContext;

        public DatPQShopDbContext Init()
        {
            return dbContext ?? (dbContext = new DatPQShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}