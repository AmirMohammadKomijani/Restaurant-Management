using WebApplication1.Model;

namespace WebApplication1.Repository.IRepository
{
    public interface IFoodRepository : IRepository<Food>
    {
        Task<Food> Update(Food food);
    }
}
