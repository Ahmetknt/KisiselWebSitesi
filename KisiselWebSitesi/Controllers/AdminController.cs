using KisiselWebSitesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebSitesi.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var deger = c.AnaSayfa.ToList();
            return View(deger);
        }
        public ActionResult AnaSayfaGetir(int id)
        {
            var AnaSayfaGetir = c.AnaSayfa.Find(id);
            return View("AnaSayfaGetir",AnaSayfaGetir);
        }

        public ActionResult AnaSayfaGuncelle(AnaSayfa güncelle)
        {
            var anasayfagüncelle = c.AnaSayfa.Find(güncelle.id);
            anasayfagüncelle.isim = güncelle.isim;
            anasayfagüncelle.unvan = güncelle.unvan;
            anasayfagüncelle.profil = güncelle.profil;
            anasayfagüncelle.iletisim = güncelle.iletisim;
            anasayfagüncelle.aciklama = güncelle.aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ikonListesi()
        {
            var deger = c.ikonlar.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniIkon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniIkon(İkonlar p)
        {
            c.ikonlar.Add(p);
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
        }
        public ActionResult ikonGetir(int id)
        {
            var ikongetir = c.ikonlar.Find(id);
            return View("ikonGetir",ikongetir);
        }
        public ActionResult ikonGuncelle(İkonlar ikongüncelle)
        {
            var ikongetir = c.ikonlar.Find(ikongüncelle.id);
            ikongetir.ikon = ikongüncelle.ikon;
            ikongetir.link = ikongüncelle.link;
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
            
        }
        public ActionResult ikonSil(int id)
        {
            var sil = c.ikonlar.Find(id);
            c.ikonlar.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
        }
    }
}