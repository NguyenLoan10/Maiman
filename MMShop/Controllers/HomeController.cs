using MMShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMShop.Controllers
{
    public class HomeController : Controller
    {
        QLSSNDKEntities _db = new QLSSNDKEntities();
        public ActionResult Index()
        {
            return View(_db.SanPhams.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}