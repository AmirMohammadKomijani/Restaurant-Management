using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        private readonly ApplicationDbContext _db;

        public FoodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Food> Update(Food food)
        {
            _db.foods.Update(food);
            await _db.SaveChangesAsync();
            return food;
        }
    }
}
