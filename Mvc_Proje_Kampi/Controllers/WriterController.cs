using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterValidator writerValidator = new WriterValidator();//hata var mı yok mu kısmına gidiyor.
        WriterManager wm = new WriterManager(new EfWriterDal());
        [Authorize]
        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer) 
        {
            ValidationResult results= writerValidator.Validate(writer); //kontrol sağlanır.
            if (results.IsValid)
            {
                wm.WriterAddBL(writer); //ekleme yapılıyor parametreden gelen değeri
                return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult EditWriter(int id) 
        {
            var writerValue=wm.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer) 
        {
            ValidationResult results = writerValidator.Validate(writer); //kontrol sağlanır.
            if (results.IsValid)
            {
                wm.WriterUpdateBL(writer);
                return RedirectToAction("Index");
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
    }
}