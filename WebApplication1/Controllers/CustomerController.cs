using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Model.DTO.CustomerDTOs;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly ApplicationDbContext _db;
        private readonly ICustomerRepository _dbCustomer;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository dbCustomer, IMapper mapper)
        {
            _dbCustomer = dbCustomer;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCustomerDto>>> GetCustomers()
        {
            // mapper approach

            //var customers = await _db.customers.ToListAsync();
            //return Ok(_mapper.Map<List<GetCustomerDto>>(customers));

            IEnumerable<Customer> customerList = await _dbCustomer.getAll();
            return Ok(_mapper.Map<List<GetCustomerDto>>(customerList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetCustomerDto>> GetOneCustomer([FromRoute] int id)
        {
            // mapper approach
            //var customer = await _db.customers.FirstOrDefaultAsync(c => c.Id == id);
            //return Ok(_mapper.Map<GetCustomerDto>(customer));

            Customer customer = await _dbCustomer.getOne(u => u.Id == id);
            return Ok(_mapper.Map<GetCustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<GetCustomerDto>> CreateCustomer([FromBody] CreateCustomerDto crCustomer)
        {

            // mapper approach
            //var newCustomer = _mapper.Map<Customer>(crCustomer);
            //await _db.AddAsync(newCustomer);
            //await _db.SaveChangesAsync();
            //var lastCustomer = await _db.customers.OrderBy(c => c.Id).LastAsync();
            //return Ok(_mapper.Map<GetCustomerDto>(lastCustomer));

            Customer customer = _mapper.Map<Customer>(crCustomer);
            await _dbCustomer.Create(customer);
            return Ok(customer);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetCustomerDto>> UpdateCustomer([FromBody] UpdateCustomerDto upCustomer, [FromRoute] int id)
        {
            // mapper approach
            //var customer = await _db.customers.FirstOrDefaultAsync(c => c.Id == id);
            //var updatedCustomer = _mapper.Map(upCustomer,customer);
            //_db.customers.Update(updatedCustomer);
            //await _db.SaveChangesAsync();
            //return Ok(_mapper.Map<GetCustomerDto>(updatedCustomer));

            Customer customer = _mapper.Map<Customer>(upCustomer);
            await _dbCustomer.Update(customer);
            return Ok(upCustomer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GetCustomerDto>> DeleteCustomer([FromRoute]int id)
        {
            // mapper approach
            //var customer = await _db.customers.FirstOrDefaultAsync(c => c.Id==id);
            //_db.customers.Remove(customer);
            //await _db.SaveChangesAsync();
            //return NoContent();

            Customer customer = await _dbCustomer.getOne(u => u.Id == id);
            await _dbCustomer.Remove(customer);
            return NoContent();
        }
    }
}
