using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class ChefRepository : Repository<Chef>, IChefRepository
    {
        private readonly ApplicationDbContext _db;

        public ChefRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Chef> Update(Chef chef)
        {
            _db.chefs.Update(chef);
            await _db.SaveChangesAsync();
            return chef;
        }
    }
}
