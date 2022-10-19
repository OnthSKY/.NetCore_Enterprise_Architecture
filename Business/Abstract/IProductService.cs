using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategory(int desiredCategoryId);

        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
