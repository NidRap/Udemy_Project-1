using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Udemy_Project_1.Data;
using Udemy_Project_1.Models;
using Udemy_Project_1.Repository.IRepository;

namespace Udemy_Project_1.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) {
            _db = db;
        }
        public async Task Create(Villa entity)
        {
            await _db.Villas1.AddAsync(entity);
            await Save();
        }

        public async Task<Villa> Get(Expression<Func<Villa,bool>> filter = null, bool tracked = true)
        {
            IQueryable<Villa> query = _db.Villas1;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Villa>> GetAll(Expression<Func<Villa , bool>> filter = null)
        {
            IQueryable<Villa> query = _db.Villas1;

            if (filter != null)
            {


                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task Remove(Villa entity)
        {
            _db.Villas1.Remove(entity);
            await Save();

        }

        public async Task Save()
        {
            await  _db.SaveChangesAsync();
        }
    }
}
