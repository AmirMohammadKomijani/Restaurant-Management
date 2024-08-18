using WebApplication1.Model;

namespace WebApplication1.Repository.IRepository
{
    public interface IChefRepository : IRepository<Chef>
    {
        Task<Chef> Update(Chef chef);
    }
}
