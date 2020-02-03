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
        [HttpGet("RemoveProje")]
        public async Task<IActionResult> RemoveProje(int id)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var result = 0;
            try
            {
                var proje = new Proje()
                {
                    Id = id
                };
                db.Attach(proje);
                db.Remove(proje);
                await db.SaveChangesAsync();
                result = 1;
            }
            catch
            {
                result = 2;
            }

            return Ok(result);
        }
   [HttpGet("RemoveModul")]
        public async Task<IActionResult> RemoveModul(int id)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var result=0;
           try{
            var model = await db.Moduller.FindAsync(id);
            db.Remove(model);
            await db.SaveChangesAsync();
            result=1;
            }
            catch{
            result=2;
            }
            // return RedirectToAction("Modul", "Admin", new { projeid = projeid });
            return Ok(result);
        }


        [HttpGet("RemoveRaporTur")]

        public async Task<IActionResult> RemoveRaporTur(int id)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var result=0;
            try{
            var model = await db.RaporTurleri.FindAsync(id);
            db.Remove(model);
            await db.SaveChangesAsync();
            result=1;
            }
            catch{
                result=2;
            }

             return Ok(result);
        }
        [HttpGet("RemoveRapor")]
        public async Task<IActionResult> RemoveRapor(int id)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var result=0;
            try{
            var model = await db.Raporlar.FindAsync(id);
            db.Remove(model);
            await db.SaveChangesAsync();
            result=1;
            }
            catch{
                result=2;
            }
            
              return Ok(result);
        }
    }
}