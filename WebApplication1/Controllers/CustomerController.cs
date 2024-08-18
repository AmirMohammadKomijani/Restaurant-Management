using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Model.DTO.CustomerDTOs;

namespace WebApplication1.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CustomerController(ApplicationDbContext db,IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCustomerDto>>> GetCustomers()
        {
            var customers = await _db.customers.ToListAsync();
            return Ok(_mapper.Map<List<GetCustomerDto>>(customers));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetCustomerDto>> GetOneCustomer([FromRoute] int id)
        {
            var customer = await _db.customers.FirstOrDefaultAsync(c => c.Id == id);
            return Ok(_mapper.Map<GetCustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<GetCustomerDto>> CreateCustomer([FromBody] CreateCustomerDto crCustomer)
        {
            
            var newCustomer = _mapper.Map<Customer>(crCustomer);
            await _db.AddAsync(newCustomer);
            await _db.SaveChangesAsync();
            var lastCustomer = await _db.customers.OrderBy(c=> c.Id).LastAsync();
            return Ok(_mapper.Map<GetCustomerDto>(lastCustomer));
        }

    }
}
