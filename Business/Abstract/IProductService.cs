using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategory(int desiredCategoryId);
        IDataResult<List<Product>> GetByUnitPrice(int min, int max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}
