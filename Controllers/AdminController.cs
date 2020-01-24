using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public AdminController(AppDbContext db)
        {
            this.db = db;
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

        public async Task<IActionResult> EditProje(int id)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await db.Projeler.FindAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProje(Proje proje)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

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

            db.Projeler.Add(proje);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Modul(int id)
        {
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await db.Moduller.Where(a => a.ProjeId == id).OrderBy(a => a.Sira).ToListAsync();

            return View(model);
        }
        public IActionResult AddModul()
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

            db.Add(modul);
            await db.SaveChangesAsync();

            return RedirectToAction("Modul");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
