using BeginnerApiProject.WebApi.Context;
using BeginnerApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeginnerApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var chefs = _context.Chefs.ToList();
            return Ok(chefs);
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Chef created successfully");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Chef not found");
            }
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok("Chef deleted successfully");
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chefs.Find(id);
            if (value == null)
            {
                return NotFound("Chef not found");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Chef updated successfully");
        }
    }
}
