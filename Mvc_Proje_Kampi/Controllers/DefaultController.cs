using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    [AllowAnonymous] //otentike olduk..
    public class DefaultController : Controller
    {
        // GET: Default
        ContentManager cm = new ContentManager(new EfContentDal());   
        TitleManager tm = new TitleManager(new EfTitleDal());
        public ActionResult Titles() 
        {
            var titlelist = tm.GetList();
            return View(titlelist);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist=cm.GetListByTitleID(id);
            return PartialView(contentlist);
        }
    }
}