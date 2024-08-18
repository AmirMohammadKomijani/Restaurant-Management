using WebApplication1.Model;

namespace WebApplication1.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> Update(Customer customer);
    }
}
