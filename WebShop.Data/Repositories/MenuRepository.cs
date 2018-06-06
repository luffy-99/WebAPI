using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data.Infrastructure;
using WebShop.Model.Models;

namespace WebShop.Data.Repositories
{
    public interface IMenu : IRepository<Menu>
    {

    }
    public class MenuRepository: RepositoryBase<Menu>, IMenu
    {
        public MenuRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
