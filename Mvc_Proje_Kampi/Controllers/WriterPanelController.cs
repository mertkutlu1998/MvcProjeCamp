using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        TitleManager tm = new TitleManager(new EfTitleDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator wv= new WriterValidator();
        Context c = new Context();
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {      
            string p = (string)Session["WriterMail"];
            ViewBag.a = p;
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue=wm.GetByID(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer) 
        {
            ValidationResult results = wv.Validate(writer); //kontrol sağlanır.
            if (results.IsValid) //eğer olay dogruysa
            {
                wm.WriterUpdateBL(writer);
                return RedirectToAction("AllTitle","WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyTitle(string p) 
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var titlevalue = tm.GetListByWriter(writeridinfo);
            return View(titlevalue);
        }
        [HttpGet]
        public ActionResult NewTitle() 
        {       
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();
            ViewBag.valuectgry = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewTitle(Title title) 
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            title.TitleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            title.WriterID = writeridinfo;
            title.TitleStatus = true;
            tm.TitleAddBL(title);
            return RedirectToAction("MyTitle");
        }
        [HttpGet]
        public ActionResult EditTitle(int id)
        {
            
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();
            ViewBag.valuectgry = valuecategory;
            var Titlevalue = tm.GetByID(id);
            return View(Titlevalue);
        }
        [HttpPost]
        public ActionResult EditTitle(Title title)
        { 
            tm.TitleUpdateBL(title);
            return RedirectToAction("MyTitle");
        }
        public ActionResult DeleteTitle(int id) 
        {
            // false ya da true yapacağız.
            var TitleValue = tm.GetByID(id); //Id'yi aldık değişkene atadık.
            TitleValue.TitleStatus = false;
            tm.TitleDeleteBL(TitleValue);//titlevalueden gelen değeri silme işlemi 
            return RedirectToAction("MyTitle");
        }
        public ActionResult AllTitle(int sayfa=1)
        {
            var titles = tm.GetList().ToPagedList(sayfa, 4);
            return View(titles);
        }
    }
}

   //   < customErrors mode = "On" >

   //       < error statusCode = "404" redirect = "/ErrorPage/Page404" /> < !---hata sayfaları için kodlar-->
	  //</customErrors>