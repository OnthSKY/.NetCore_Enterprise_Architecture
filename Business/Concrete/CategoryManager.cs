using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>( _categoryDal.GetAll(), Messages.ListedCategroies);
        }
        
        [CacheAspect]
        public IDataResult<Category> GetById(int desiredCategoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == desiredCategoryId));
        }
    }
}
