using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CustomerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionsController : Controller
    {
        private readonly CrmdatabaseContext _context;

        public InteractionsController(CrmdatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterctions()
        {
            return Ok(await _context.Interactions.ToListAsync());
        }

    }
}


