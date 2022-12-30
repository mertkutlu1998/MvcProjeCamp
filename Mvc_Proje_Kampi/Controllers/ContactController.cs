using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager com = new ContactManager(new EfContactDal());
        ContactValidator cov=new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = com.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id) //sen contactdetailsi id'ye göre getirme işlemi
        {
            var detailsvalue = com.GetByID(id);
            return View(detailsvalue);
        }
        public PartialViewResult MessageListMenu() 
        {
            return PartialView(); //parçalı view göndürücek
        }
    }
}