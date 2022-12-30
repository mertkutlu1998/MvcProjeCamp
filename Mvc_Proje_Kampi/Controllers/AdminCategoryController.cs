using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        //[Authorize(Roles="B")] //yetkilendirme otantike anlamına geliyor.
        public ActionResult Index(int sayfa=1)
        {
            var kategori = cm.GetList().ToPagedList(sayfa, 3);
            return View(kategori);
        }
        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category) 
        {
            CategoryValidator ctgryvldtr=new CategoryValidator();
            ValidationResult results=ctgryvldtr.Validate(category);
            if (results.IsValid)
            {
                cm.CategoryAddBL(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public ActionResult DeleteCategory(int id) 
        {
            var ctgrydelete = cm.GetByID(id); //cm == controller manager
            cm.CategoryDeleteBL(ctgrydelete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
            var categoryUpdate=cm.GetByID(id);
            return View(categoryUpdate); // değişkeninde içeriği gelecek.
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cm.CategoryUpdateBL(category);
            return RedirectToAction("Index"); // değişkeninde içeriği gelecek.
        }
    }
}