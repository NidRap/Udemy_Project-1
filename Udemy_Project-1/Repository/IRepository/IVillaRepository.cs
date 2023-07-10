using System.Linq.Expressions;
using Udemy_Project_1.Models;

namespace Udemy_Project_1.Repository.IRepository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        //Task<List<Villa>>  GetAll(Expression<Func<Villa , bool>> filter = null);
        //Task<Villa>  Get(Expression<Func<Villa , bool>> filter = null , bool tracked = true);

        //Task Create(Villa entity);
        //Task Remove(Villa entity);
       Task<Villa> Update(Villa entity);

        //Task Save();
    }
}
