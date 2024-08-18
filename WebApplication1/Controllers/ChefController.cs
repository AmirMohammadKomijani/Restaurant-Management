using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Model.DTO.ChefDTOs;
using WebApplication1.Model.DTO.UpdateChefDto;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/chefs")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        //private readonly ApplicationDbContext _db;
        private readonly IChefRepository _dbChef;
        private readonly IMapper _mapper;

        public ChefController(IChefRepository dbChef, IMapper mapper)
        {
            _dbChef = dbChef;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetChefDto>>> GetChefs()
        {
            // mapper approach
            //var chefs = await _db.chefs.ToListAsync();
            //return Ok(_mapper.Map<List<GetChefDto>>(chefs));

            IEnumerable<Chef> chefList = await _dbChef.getAll();
            return Ok(_mapper.Map<List<GetChefDto>>(chefList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetChefDto>> GetOneChef([FromRoute] int id)
        {
            // mapper approach
            //var chef = await _db.chefs.FirstOrDefaultAsync(c => c.Id == id);
            //return Ok(_mapper.Map<GetChefDto>(chef));

            Chef chef = await _dbChef.getOne(u => u.Id == id);
            return Ok(_mapper.Map<GetChefDto>(chef));
        }

        [HttpPost]
        public async Task<ActionResult<GetChefDto>> CreateChef([FromBody] CreateChefDto crChef)
        {
            // mapper approach
            //var newChef = _mapper.Map<Chef>(crChef);
            //await _db.AddAsync(newChef);
            //await _db.SaveChangesAsync();
            //var lastChef = await _db.chefs.OrderBy(c => c.Id).LastAsync();
            //return Ok(_mapper.Map<GetChefDto>(lastChef));


            Chef chef = _mapper.Map<Chef>(crChef);
            await _dbChef.Create(chef);
            return Ok(chef);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetChefDto>> UpdateChef([FromBody] UpdateChefDto upChef, [FromRoute] int id)
        {
            // mapper approach
            //var chef = await _db.chefs.FirstOrDefaultAsync(c => c.Id == id);
            //var updatedChef = _mapper.Map(upChef, chef);
            //_db.chefs.Update(updatedChef);
            //await _db.SaveChangesAsync();
            //return Ok(_mapper.Map<GetChefDto>(updatedChef));

            Chef chef = _mapper.Map<Chef>(upChef);
            await _dbChef.Update(chef);
            return Ok(upChef);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GetChefDto>> DeleteChef([FromRoute] int id)
        {
            // mapper approach
            //var chef = await _db.chefs.FirstOrDefaultAsync(c => c.Id == id);
            //_db.chefs.Remove(chef);
            //await _db.SaveChangesAsync();
            //return NoContent();

            Chef chef = await _dbChef.getOne(u => u.Id == id);
            await _dbChef.Remove(chef);
            return NoContent();
        }
    }
}
