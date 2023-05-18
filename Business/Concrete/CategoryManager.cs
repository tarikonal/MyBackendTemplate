using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //İş Kodları
           // return _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList(), Messages.ProductsListed);
        }



        public IResult Add(Category category)
        {

            _categoryDal.Add(category);

            return new SuccessResult(Messages.ProductAdded);
        }

        //Delete(Category category)
        
        public IResult Delete(Category category)
        {   
            _categoryDal.Delete(category);
            return new SuccessResult("Silindi");
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("GÜNCELLENDİ");
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        //select * from Categories where categoryId=3
       // public Category GetById(int categoryId)
       // {
        //    return _categoryDal.Get(c=>c.CategoryId == categoryId); 
        //}
    }
}
