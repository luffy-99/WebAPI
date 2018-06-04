namespace WebShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private WebShopDbContext dbContext;

        public WebShopDbContext Init()
        {
            return dbContext ?? (dbContext = new WebShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}