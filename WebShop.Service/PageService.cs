using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data.Infrastructure;
using WebShop.Data.Repositories;
using WebShop.Model.Models;

namespace WebShop.Service
{
    public interface IPageService
    {
        Page GetByAlias(string alias);
    }
    public class PageService: IPageService
    {
        IUnitOfWork _unitOfWork;
        IPageRepository _pageRepository;
        public PageService(IUnitOfWork unitOfWork, IPageRepository pageRepository)
        {
            this._pageRepository = pageRepository;
            this._unitOfWork = unitOfWork;
        }
        public Page GetByAlias(string alias)
        {
            return _pageRepository.GetSingleByCondition(x => x.Alias == alias);
        }
    }
}
