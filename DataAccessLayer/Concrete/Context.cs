using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext //veri tabanındaki tablolara denk gelcek şekilde bir başka sınıftan kalıtsal yolla almak için : kullanıyoruz
    {
        //About kabul etmez çünkü farklı bir katmanda o yüzden referans oalrak ekleme yapıyoruz. Abouts bizim sql de ki veritabanında yansıyan tablo kısmıdır.sql tablo olarak yansıtacak Dbcontext
        public DbSet<About> Abouts { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
