using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;



namespace CustomerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly CrmdatabaseContext _context;

        public ProductController(CrmdatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context
                .Products.Include( p => p.Tickets)
                .ToListAsync()); 
        }
 
    }
}
