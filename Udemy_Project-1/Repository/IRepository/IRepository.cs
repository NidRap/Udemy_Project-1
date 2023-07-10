using System.Linq.Expressions;
using Udemy_Project_1.Models;

namespace Udemy_Project_1.Repository.IRepository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true);

        Task Create(T entity);
        Task Remove(T entity);
       
        Task Save();
    }
}
