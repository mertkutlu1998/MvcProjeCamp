using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class TitleController : Controller
    {
        // GET: Title
        //listeleme işlemi yapıcağız.
        TitleManager tm = new TitleManager(new EfTitleDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var titleValues = tm.GetList().ToPagedList(sayfa,4);
            return View(titleValues);
        }
        public ActionResult TitleReport() 
        {
            var titleValues = tm.GetList();
            return View(titleValues);
        }
        [HttpGet]
        public ActionResult AddTitle() 
        {
            //sayfa yüklendiğinde bir liste göndericek bir değer seçicek
            //Dropdown üzerinden gerçekleştireceğiz.
            //2 değerimiz var
            //valuemember seçtiğimiz değerin ID categoryId örneğin Value
            //displaymember seçmiş olduğumuz değerin görüntüsü yani kendisi categoryName örneğin Text
            //Kod Açıklaması: Yeni bir şey eklerken Id gözükmesini istemiyor dropdown yardımıyla id çekip direk category isimlerinin gösterilmesini istiyoruz.
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+" "+x.WriterSurName,
                                                      Value = x.WriterID.ToString(),
                                                  }).ToList();
            ViewBag.valuectgry = valuecategory; //viewbag: viewbag yardımıyla view'e taşıma işlemi
            ViewBag.valuewrtr = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddTitle(Title title) 
        {
            title.TitleDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            tm.TitleAddBL(title);
            return RedirectToAction("Index");
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
            var TitleValue=tm.GetByID(id);
            return View(TitleValue);
        }
        [HttpPost]
        public ActionResult EditTitle(Title title) 
        {
            tm.TitleUpdateBL(title);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTitle(int id) 
        {
            //false ya da true yapacağız.
            var TitleValue=tm.GetByID(id); //Id'yi aldık değişkene atadık.
            TitleValue.TitleStatus = false;
            tm.TitleDeleteBL(TitleValue);//titlevalueden gelen değeri silme işlemi 
            return RedirectToAction("Index");
        }
    }
}