using System.Linq.Expressions;
using Udemy_Project_1.Models;

namespace Udemy_Project_1.Repository.IRepository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
       
       Task<VillaNumber> Update(VillaNumber entity);

    }
}
