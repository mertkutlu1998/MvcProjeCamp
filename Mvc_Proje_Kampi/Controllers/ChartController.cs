
using Mvc_Proje_Kampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart() 
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList() 
        {
            List<CategoryClass> ct=new List<CategoryClass>();
            ct.Add(new CategoryClass() 
            {
                KategoriName = "Yazılım",
                KategoriCount = 1
            });
            ct.Add(new CategoryClass()
            {
                KategoriName = "Haber",
                KategoriCount = 5
            });
            ct.Add(new CategoryClass()
            {
                KategoriName = "Spor",
                KategoriCount = 6
            });
            ct.Add(new CategoryClass()
            {
                KategoriName = "Seyahat",
                KategoriCount = 3
            });
            return ct;
        }
    }
}