using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webdeneme.Models;
namespace webdeneme.Controllers
{
    public class RandevuController : Controller
    {
        private readonly KuaforDbContext _veritabani;

        public RandevuController(KuaforDbContext veritabani)
        {
            _veritabani = veritabani;
        }

        //kullanici giriş kontrolü
        private bool KullaniciGirisYapmisMi()
        {
            return HttpContext.Session.GetString("KullaniciId") != null;
        }


        public IActionResult Hizmetler()
        {
            if (!KullaniciGirisYapmisMi())
            {
                return RedirectToAction("GirisYap", "Musteri");
            }

            var hizmetler = _veritabani.Islemler.ToList();
            return View(hizmetler);
        }


        public IActionResult Uzmanlar(int hizmetId)
        {
            if (!KullaniciGirisYapmisMi())
            {
                return RedirectToAction("GirisYap", "Musteri");
            }

            var uzmanlar = _veritabani.Calisanlar
                .Where(u => u.Beceriler.Contains(hizmetId.ToString()) && u.MusaitMi)
                .ToList();
            return View(uzmanlar);
        }


        public IActionResult RandevuAl(int uzmanId, int hizmetId)
        {
            if (!KullaniciGirisYapmisMi())
            {
                return RedirectToAction("GirisYap", "Musteri");
            }

            var uzman = _veritabani.Calisanlar.Find(uzmanId);
            var hizmet = _veritabani.Islemler.Find(hizmetId);

            if (uzman == null || hizmet == null)
            {
                return NotFound();
            }

            return View(new Randevu
            {
                CalisanId = uzmanId,
                IslemId = hizmetId,
                RandevuTarihi = DateTime.Now
            });
        }


        [HttpPost]
        public IActionResult RandevuOlustur(Randevu randevu)
        {
            if (!KullaniciGirisYapmisMi())
            {
                return RedirectToAction("GirisYap", "Musteri");
            }

            if (ModelState.IsValid)
            {
                randevu.MusteriId = int.Parse(HttpContext.Session.GetString("KullaniciId"));
                _veritabani.Randevular.Add(randevu);
                _veritabani.SaveChanges();
                return RedirectToAction("Randevularim");
            }
            return View(randevu);
        }


        public IActionResult Randevularim()
        {
            if (!KullaniciGirisYapmisMi())
            {
                return RedirectToAction("GirisYap", "Musteri");
            }

            var kullaniciId = int.Parse(HttpContext.Session.GetString("KullaniciId"));
            var randevular = _veritabani.Randevular
                .Include(r => r.Islem)
                .Include(r => r.Calisan)
                .Where(r => r.MusteriId == kullaniciId)
                .ToList();
            return View(randevular);
        }

    }
}