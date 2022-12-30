using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index() 
        {
            return View();
        }
        public ActionResult GellAlContent(string p) //arama işlemi için dışaran parametre göndermeliyiz. 
        {
            var contentvalues = cm.GetList(p); //arama metodu           
            //var contentvalues = c.Contents.ToList();
            return View(contentvalues);
            
        }
        public ActionResult ContentByTitle(int id)  //içerikleri getir title'a göre getir anlamına gelen bir metotdur. Id göre getiricez.
        {
            var contentvalues = cm.GetListByTitleID(id); //listeyi getir ID'ya göre anlamına gelir.
            return View(contentvalues);
        }
    }
}