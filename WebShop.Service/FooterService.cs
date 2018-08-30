using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Common;
using WebShop.Data.Infrastructure;
using WebShop.Data.Repositories;
using WebShop.Model.Models;

namespace WebShop.Service
{
    public interface IFooterService
    {
        IEnumerable<Footer> GetAll();
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }
    public class FooterService : IFooterService
    {
        public IFooterRepository _IFooterRepository;
        public IUnitOfWork _IUnitOfWork;
        public ISlideRepository _ISlideRepository;
        public FooterService(IFooterRepository IFooterRepository, IUnitOfWork IUnitOfWork, ISlideRepository slideRepository)
        {
            this._IFooterRepository = IFooterRepository;
            this._IUnitOfWork = IUnitOfWork;
            this._ISlideRepository = slideRepository;
        }
        public IEnumerable<Footer> GetAll()
        {
            return _IFooterRepository.GetAll();
        }
        public Footer GetFooter()
        {
            return _IFooterRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _ISlideRepository.GetAll();
        }

        public void Save()
        {
            _IUnitOfWork.Commit();
        }
    }
}
