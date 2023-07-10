using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Udemy_Project_1.Data;
using Udemy_Project_1.Models;
using Udemy_Project_1.Repository.IRepository;
using Udemy_Project_1.Repository.IRepository.IRepository;

namespace Udemy_Project_1.Repository
{
    public class VillaNumberRepository :Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberRepository(ApplicationDbContext db):base(db) {
            _db = db;
        }
      
        public async Task<VillaNumber> Update(VillaNumber entity)
        {
            entity.UpdatedTime = DateTime.Now;
            _db.VillaNumber.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
