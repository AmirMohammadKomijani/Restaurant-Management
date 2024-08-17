using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController:ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public FoodController(ApplicationDbContext db,IMapper mapper)
        {
            _db= db;
            _mapper= mapper;
        }
    }
}
