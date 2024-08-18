using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Model.DTO.FoodDTOs;
using WebApplication1.Model.DTO.UpdateFoodDto;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController:ControllerBase
    {
        //private readonly ApplicationDbContext _db;
        private readonly IFoodRepository _dbFood;
        private readonly IMapper _mapper;

        public FoodController(IFoodRepository dbFood, IMapper mapper)
        {
            _dbFood = dbFood;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFoodDto>>> GetFoods()
        {
            // mapper approach
            //var foods = await _db.foods.ToListAsync();
            //return Ok(_mapper.Map<List<GetFoodDto>>(foods));

            IEnumerable<Food> foodList = await _dbFood.getAll();
            return Ok(_mapper.Map<List<GetFoodDto>>(foodList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetFoodDto>> GetOneFood([FromRoute] int id)
        {
            // mapper approach
            //var id = (int)HttpContext.Request.RouteValues["id"];
            //var food = await _db.foods.FirstOrDefaultAsync(f => f.Id == id);
            //return Ok(food);

            Food food = await _dbFood.getOne(u => u.Id == id);
            return Ok(_mapper.Map<GetFoodDto>(food));
        }

        [HttpPost]
        public async Task<ActionResult<Food>> CreateFood([FromBody] CreateFoodDto crFood)
        {
            // mapper approach
            //var food = _mapper.Map<Food>(crFood);
            //await _db.foods.AddAsync(food);
            //await _db.SaveChangesAsync();
            //return food;

            Food food = _mapper.Map<Food>(crFood);
            await _dbFood.Create(food);
            return Ok(food);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Food>> UpdateFood([FromBody] UpdateFoodDto upFood, [FromRoute] int id)
        {
            // mapper approach
            //int id = (int)HttpContext.Request.RouteValues["id"];
            //var food = await _db.foods.FirstOrDefaultAsync(f => f.Id == id);
            //var updated_food = _mapper.Map(upFood, food);
            //_db.foods.Update(updated_food);
            //await _db.SaveChangesAsync();
            //return Ok(updated_food);

            Food food = _mapper.Map<Food>(upFood);
            await _dbFood.Update(food);
            return Ok(upFood);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Food>> DeleteFood([FromRoute] int id)
        {
            // mapper approach
            //int id = (int)HttpContext.Request.RouteValues["id"];
            //var food = await _db.foods.FirstOrDefaultAsync(f => f.Id == id);
            //_db.foods.Remove(food);
            //await _db.SaveChangesAsync();
            //return NoContent();

            Food food = await _dbFood.getOne(u => u.Id == id);
            await _dbFood.Remove(food);
            return NoContent();
        }

        [HttpGet("filterPrice")]
        public async Task<ActionResult<IEnumerable<GetFoodDto>>> FoodFilterPrice([FromQuery] float? lowerPrice, [FromQuery] float? higherPrice)
        {
            // mapper approach
            //var foods = await _db.foods.Where(f=> f.Price >= lowerPrice && f.Price <= higherPrice).ToListAsync();
            //return Ok(_mapper.Map<List<GetFoodDto>>(foods));

            var foods = await _dbFood.getAll(f => f.Price >= lowerPrice && f.Price <= higherPrice);
            return Ok(_mapper.Map<List<GetFoodDto>>(foods));

        }
    }
}
