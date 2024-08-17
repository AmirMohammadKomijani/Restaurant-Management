using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/chefs")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ChefController(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }


    }
}
