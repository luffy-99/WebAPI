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
    public interface IContactDetailService
    {
        ContactDetail GetDefaultCotact();
    }
    public class ContactDetailService: IContactDetailService
    {
        IUnitOfWork _unitOfWork;
        IContactDetailRepository _contactDetailRepository;
        public ContactDetailService(IUnitOfWork unitOfWork, IContactDetailRepository contactDetailRepository)
        {
            this._unitOfWork = unitOfWork;
            this._contactDetailRepository = contactDetailRepository;
        }

        public ContactDetail GetDefaultCotact()
        {
            return _contactDetailRepository.GetSingleByCondition(x => x.Status);
        }
    }
}
