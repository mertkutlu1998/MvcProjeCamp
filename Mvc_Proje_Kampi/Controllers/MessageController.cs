using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm=new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageinlist = mm.GetListInbox(p);
            return View(messageinlist); //bize gelen mesajları listelicez.
        }
        public ActionResult Sendbox(string p) 
        {
            var messagesendlist=mm.GetListSendbox(p);
            return View(messagesendlist);
        }
        public ActionResult GetInBoxMessageDetails(int id) //sen contactdetailsi id'ye göre getirme işlemi
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id) //sen contactdetailsi id'ye göre getirme işlemi
        {
            var value = mm.GetByID(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message) 
        {
            ValidationResult results = messageValidator.Validate(message); //kontrol sağlanır.
            if (results.IsValid)
            {
                message.MessageDate= DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(message); //ekleme yapılıyor parametreden gelen değeri
                return RedirectToAction("SendBox");
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