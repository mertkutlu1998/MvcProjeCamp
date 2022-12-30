using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index() //listeleme sayfasıdır. ındex
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList(); //categoryvalues'in içerisine category tablosundaki olan verileri getircek
            return View(categoryvalues); //view'e aktarılcak
        }
        [HttpGet]// sayfa yenilendiğinde bu çalışacak.
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost] //bir butona tıklandığında bu çalışcak
        public ActionResult AddCategory(Category category)
        {
            //  cm.CategoryAddBL(category);
            CategoryValidator categoryValidator = new CategoryValidator();//Kategori eklerken boş bıraktığımızda hata vermesi için kullandık.
            ValidationResult results = categoryValidator.Validate(category); //result değişkeni categoryvalidator doğruluğunu geleni kontrol et
            if (results.IsValid)
            {
                cm.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(); //ekleme işleminden sonra verilerin listelendiği metoda götürecek.
        }
    }
}