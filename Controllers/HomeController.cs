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
    public class HomeController : Controller
    {
        private readonly AppDbContext db;

        public HomeController(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("userid") == null)
            {
                return RedirectToAction("Login");
            }

            var projeid = Utils.SD.projeid;

            var moduls = await db.Modul.Where(a => a.ProjeId == projeid).OrderBy(a => a.Sira).ToListAsync();

            return View(moduls);
        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Kullanici user)
        {
            var dbuser = await db.Kullanici.Where(a => a.Username == user.Username && a.Password == user.Password).FirstOrDefaultAsync();
            if (dbuser != null)
            {
                HttpContext.Session.SetInt32("userid", dbuser.Id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["error"] = "*Kullanıcı adı veya şifre hatalı";
            }

            return View();
        }

        public async Task<IActionResult> Rapor(int id)
        {
            if (HttpContext.Session.GetInt32("userid") == null)
            {
                return RedirectToAction("Login");
            }

            var reports = await db.Raporlar.Where(a => a.ModulId == id).OrderBy(a => a.Sira).ToListAsync();

            return View(reports);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
