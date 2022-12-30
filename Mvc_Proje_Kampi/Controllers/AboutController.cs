using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = am.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about) 
        {
            am.AboutAddBL(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial() 
        {
            return PartialView();
        }
    }
}