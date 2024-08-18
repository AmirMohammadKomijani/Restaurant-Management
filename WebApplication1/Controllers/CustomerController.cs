using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
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
            return Ok(_mapper.Map<GetCustomerDto>(customers));
        }


    }
}
