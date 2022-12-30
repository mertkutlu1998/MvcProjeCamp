using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Proje_Kampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IWriterLoginManager wlm = new IWriterLoginManager(new EfWriterDal());
        // GET: Login
        LoginManager lm = new LoginManager(new EfLoginDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin) 
        {
            Context c=new Context();
            var adminuserinfo= c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword); ; //geriye sadece 1 değer döndürme tek admin girişi yapılacağı için
            if (adminuserinfo !=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"]=adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult WriterLogin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer) 
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword); ; //geriye sadece 1 değer döndürme tek admin girişi yapılacağı için
            var writeruserinfo=wlm.GetWriter(writer.WriterMail,writer.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}