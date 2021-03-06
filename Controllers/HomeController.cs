﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeYonetim.Data;
using ProjeYonetim.Models;
using ProjeYonetim.Models.ViewModel;

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
            var moduls = await db.Moduller.Where(a => a.ProjeId == projeid && a.Active).OrderBy(a => a.Sira).ToListAsync();

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
                HttpContext.Session.SetString("role", dbuser.Role);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["error"] = "*Kullanıcı adı veya şifre hatalı";
            }

            return View();
        }

        public async Task<IActionResult> Rapor(int modulid)
        {
            if (HttpContext.Session.GetInt32("userid") == null)
            {
                return RedirectToAction("Login");
            }
            var model = new HomeRaporViewModel()
            {
                RaporTurler = await db.RaporTurleri.Where(a => a.ModulId == modulid && a.Active).OrderBy(a => a.Sira).Select(a => new RaporTur
                {
                    Id = a.Id,
                    Adi = a.Adi
                }).ToListAsync(),
                Modul = await db.Moduller.Where(a => a.Id == modulid).Select(a => new Modul
                {
                    DemoLink = a.DemoLink
                }).FirstOrDefaultAsync()
            };

            return View(model);
        }



        public async Task<IActionResult> GetRapor(int rapor)
        {
            if (HttpContext.Session.GetInt32("userid") == null)
            {
                return RedirectToAction("Login");
            }
            var file = await db.Raporlar.FindAsync(rapor);
            var extension = System.IO.Path.GetExtension(file.Aciklama);
            string contentType = null;
            switch (extension)
            {
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".doc":
                    contentType = "application/msword";
                    break;
                case ".docx":
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;

                default:
                    contentType = "application/ocet-stream";
                    break;
            }

            return File("/files/" + file.Aciklama, contentType ?? "application/octet-stream", file.Aciklama);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
