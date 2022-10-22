using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExist(product.ProductName));

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.AddedProduct);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.DeletedProduct);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ListedProducts);

        }

        public IDataResult<List<Product>> GetAllByCategory(int desiredCategoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == desiredCategoryId), Messages.ListedProducts);
        }

        public IDataResult<Product> GetById(int desiredProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == desiredProductId), Messages.FoundProduct);
        }

        public IDataResult<List<Product>> GetByUnitPrice(int min, int max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), Messages.ListedProducts);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductsDetail(), Messages.ListedProducts);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.UpdatedProduct);
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
