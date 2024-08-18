using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Customer> Update(Customer customer)
        {
            _db.customers.Update(customer);
            await _db.SaveChangesAsync();
            return customer;
        }
    }
}
