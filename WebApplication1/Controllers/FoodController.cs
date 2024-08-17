using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Model.DTO.FoodDTOs;
using WebApplication1.Model.DTO.UpdateFoodDto;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFoodDto>>> GetFoods()
        {
            var foods = await _db.foods.ToListAsync();
            return Ok(_mapper.Map<List<GetFoodDto>>(foods));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetFoodDto>> GetOneFood([FromRoute] int id)
        {
            //var id = (int)HttpContext.Request.RouteValues["id"];
            var food = await _db.foods.FirstOrDefaultAsync(f => f.Id == id);
            return Ok(food);
        }

        [HttpPost]
        public async Task<ActionResult<Food>> CreateFood([FromBody] CreateFoodDto crFood)
        {
            var food = _mapper.Map<Food>(crFood);
            await _db.foods.AddAsync(food);
            await _db.SaveChangesAsync();
            return food;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Food>> UpdateFood([FromBody] UpdateFoodDto upFood, [FromRoute] int id)
        {
            //int id = (int)HttpContext.Request.RouteValues["id"];
            var food = await _db.foods.FirstOrDefaultAsync(f => f.Id == id);
            var updated_food = _mapper.Map(upFood, food);
            _db.foods.Update(updated_food);
            await _db.SaveChangesAsync();
            return Ok(updated_food);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Food>> DeleteFood([FromRoute] int id)
        {
            //int id = (int)HttpContext.Request.RouteValues["id"];
            var food = await _db.foods.FirstOrDefaultAsync(f => f.Id == id);
            _db.foods.Remove(food);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("filterPrice")]
        public async Task<ActionResult<IEnumerable<GetFoodDto>>> FoodFilterPrice([FromQuery] float? lowerPrice, [FromQuery] float? higherPrice)
        {
            var foods = await _db.foods.Where(f=> f.Price >= lowerPrice && f.Price <= higherPrice).ToListAsync();
            return Ok(_mapper.Map<List<GetFoodDto>>(foods));
        }
    }
}
