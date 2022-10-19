using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();

        }

        public List<Product> GetAllByCategory(int desiredCategoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId == desiredCategoryId);
        }

        public List<Product> GetByUnitPrice(int min, int max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductsDetail();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
