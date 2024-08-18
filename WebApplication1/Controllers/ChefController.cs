using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Model.DTO.ChefDTOs;
using WebApplication1.Model.DTO.UpdateChefDto;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetChefDto>>> GetChefs()
        {
            var chefs = await _db.chefs.ToListAsync();
            return Ok(_mapper.Map<List<GetChefDto>>(chefs));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetChefDto>> GetOneChef([FromRoute] int id)
        {
            var chef = await _db.chefs.FirstOrDefaultAsync(c => c.Id == id);
            return Ok(_mapper.Map<GetChefDto>(chef));
        }

        [HttpPost]
        public async Task<ActionResult<GetChefDto>> CreateChef([FromBody] CreateChefDto crChef)
        {

            var newChef = _mapper.Map<Chef>(crChef);
            await _db.AddAsync(newChef);
            await _db.SaveChangesAsync();
            var lastChef = await _db.chefs.OrderBy(c => c.Id).LastAsync();
            return Ok(_mapper.Map<GetChefDto>(lastChef));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetChefDto>> UpdateChef([FromBody] UpdateChefDto upChef, [FromRoute] int id)
        {
            var chef = await _db.chefs.FirstOrDefaultAsync(c => c.Id == id);
            var updatedChef = _mapper.Map(upChef, chef);
            _db.chefs.Update(updatedChef);
            await _db.SaveChangesAsync();
            return Ok(_mapper.Map<GetChefDto>(updatedChef));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GetChefDto>> DeleteChef([FromRoute] int id)
        {
            var chef = await _db.chefs.FirstOrDefaultAsync(c => c.Id == id);
            _db.chefs.Remove(chef);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
