using Microsoft.AspNetCore.Mvc;
using webdeneme.Models;

namespace webdeneme.Controllers
{
    public class AdminController : Controller
    {
        private readonly KuaforDbContext _veritabani;

        public AdminController(KuaforDbContext veritabani)
        {
            _veritabani = veritabani;
        }

        public IActionResult Panel()
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("GirisYap", "Musteri");
            }

            var raporlar = _veritabani.AdminRaporlar.ToList();
            return View(raporlar);
        }

        public IActionResult Calisanlar()
        {
            var calisanlar = _veritabani.Calisanlar.ToList();
            return View(calisanlar);
        }
    }
}

