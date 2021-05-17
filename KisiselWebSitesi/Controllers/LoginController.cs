using KisiselWebSitesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KisiselWebSitesi.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin ad)
        {
            var bilgiler = c.Admin.FirstOrDefault(x => x.kullaniciAdi == ad.kullaniciAdi && x.sifre == ad.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullaniciAdi, false);
                Session["kullaniciAdi"] = bilgiler.kullaniciAdi.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        
    }
}