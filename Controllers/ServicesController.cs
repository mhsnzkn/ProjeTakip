using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeYonetim.Data;
using ProjeYonetim.Models;

namespace ProjeYonetim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext db;

        public ServicesController(AppDbContext db)
        {
            this.db = db;
        }
        [HttpGet("GetRapor")]
        public async Task<IActionResult> GetRapor([FromQuery]Rapor rapor)
        {
            if (HttpContext.Session.GetInt32("userid") == null || HttpContext.Session.GetInt32("userid") == 0)
                return Unauthorized();

            var model = await db.Raporlar.Where(a => a.RaporTurId == rapor.Id).OrderBy(a => a.Sira).ToListAsync();

            return Ok(model);
        }
    }
}