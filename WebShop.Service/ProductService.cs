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
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        void Update();
        void Delete(int id);
        void Add(Product product);
        IEnumerable<Product> GetAll(string keyWord);
        IEnumerable<Product> GetLastest( int top);
        IEnumerable<Product> GetHotProduct(int top);
        IEnumerable<Product> GetProductByCategoryIdPaging(int categoryID, int page, int pageSize,string sort, out int totalRow);
        Product GetById(int id);
        void Save();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, ITagRepository tagRepository,IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(string keyWord)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            return _productRepository.GetMulti(x => x.Status && x.HomeFlag == true).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetLastest(int top)
        {
            return _productRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetProductByCategoryIdPaging(int categoryID, int page, int pageSize,string sort, out int totalRow)
        {
            var productMulti = _productRepository.GetMulti(x => x.Status && x.CategoryID == categoryID);
            switch (sort)
            {
                case "new":
                    productMulti = productMulti.OrderByDescending(x => x.CreatedDate);
                    break;
                case "popular":
                    productMulti = productMulti.OrderByDescending(x => x.ViewCount);
                    break;
                case "discount":
                    productMulti = productMulti.OrderByDescending(x => x.PromotionPrice);
                    break;
                case "price":
                    productMulti = productMulti.OrderBy(x => x.Price);
                    break;
                default:
                    break;
            }
            totalRow = productMulti.Count();
            return productMulti.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
