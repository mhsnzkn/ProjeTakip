using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeYonetim.Data;
using ProjeYonetim.Models;

namespace ProjeYonetim.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext db;
        private readonly IHostingEnvironment hosting;

        public AdminController(AppDbContext db, IHostingEnvironment hosting)
        {
            this.db = db;
            this.hosting = hosting;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await db.Projeler.ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> EditProje(int projeid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await db.Projeler.FindAsync(projeid);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProje(Proje proje)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            proje.UptDate = DateTime.Now;

            db.Projeler.Update(proje);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult AddProje()
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProje(Proje proje)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            proje.CrtDate = DateTime.Now;

            db.Projeler.Add(proje);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Modul(int projeid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await db.Moduller.Where(a => a.ProjeId == projeid).OrderBy(a => a.Sira).ToListAsync();

            return View(model);
        }
        public IActionResult AddModul(int projeid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddModul(Modul modul)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            modul.CrtDate = DateTime.Now;

            db.Add(modul);
            await db.SaveChangesAsync();

            return RedirectToAction("Modul", "Admin", new { projeid = modul.ProjeId });
        }
        public async Task<IActionResult> EditModul(int projeid, int modulid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var model = await db.Moduller.FindAsync(modulid);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditModul(Modul modul)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            modul.UptDate = DateTime.Now;

            db.Update(modul);
            await db.SaveChangesAsync();

            return RedirectToAction("Modul", "Admin", new { projeid = modul.ProjeId });
        }

        public async Task<IActionResult> RaporTuru(int modulid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await db.RaporTurleri.Where(a => a.ModulId == modulid).OrderBy(a => a.Sira).ToListAsync();

            return View(model);
        }
        public IActionResult AddRaporTuru()
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRaporTuru(RaporTur raportur)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            raportur.CrtDate = DateTime.Now;
            db.Add(raportur);
            await db.SaveChangesAsync();

            return RedirectToAction("RaporTuru", "Admin", new { projeid = raportur.ProjeId, modulid = raportur.ModulId });
        }
        public async Task<IActionResult> EditRaporTuru(int raporturuid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var model = await db.RaporTurleri.FindAsync(raporturuid);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRaporTuru(RaporTur raportur)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            raportur.UptDate = DateTime.Now;
            db.Update(raportur);
            await db.SaveChangesAsync();

            return RedirectToAction("RaporTuru", "Admin", new { projeid = raportur.ProjeId, modulid = raportur.ModulId });
        }

        public async Task<IActionResult> Raporlar(int raporturuid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await db.Raporlar.Where(a => a.RaporTurId == raporturuid).OrderBy(a => a.Sira).ToListAsync();

            return View(model);
        }
        public IActionResult AddRapor()
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRapor(Rapor rapor, IFormFile file)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            if (file != null)
            {
                try
                {
                    var filename = Path.GetFileName(file.FileName);
                    var destination = Path.Combine(hosting.WebRootPath, "files", filename);
                    using (var fs = new FileStream(destination, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                    rapor.Aciklama = filename;
                }
                catch
                {
                    rapor.Aciklama = null;
                }
            }

            rapor.CrtDate = DateTime.Now;

            db.Add(rapor);
            await db.SaveChangesAsync();

            return RedirectToAction("Raporlar", "Admin", new { projeid = rapor.ProjeId, modulid = rapor.ModulId, raporturuid = rapor.RaporTurId });
        }
        public async Task<IActionResult> EditRapor(int raporid)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var model = await db.Raporlar.FindAsync(raporid);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRapor(Rapor rapor, IFormFile file)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            if (file != null)
            {
                try
                {
                    var filename = Path.GetFileName(file.FileName);
                    var destination = Path.Combine(hosting.WebRootPath, "files", filename);
                    using (var fs = new FileStream(destination, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                    rapor.Aciklama = filename;
                }
                catch
                {
                    rapor.Aciklama = null;
                }
            }
            rapor.UptDate = DateTime.Now;
            db.Update(rapor);
            await db.SaveChangesAsync();

            return RedirectToAction("Raporlar", "Admin", new { projeid = rapor.ProjeId, modulid = rapor.ModulId, raporturuid = rapor.RaporTurId });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
