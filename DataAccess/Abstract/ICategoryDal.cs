using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //IDataResult<List<Category>> GetAll();
        //void Add(Category category);
        //void Delete(Category category);
        //void Update(Category category);

        //List<Category> GetAllByCategory(int categoryId);
    }
}
