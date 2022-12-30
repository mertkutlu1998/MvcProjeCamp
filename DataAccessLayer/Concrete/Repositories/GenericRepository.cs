using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    // İçerisinde yer alan metotlarımız tutuyor.
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c=new Context();
        DbSet<T> _object; //_object burda T değerine karşılık gelen sınıfı tutuyor.
        //karşılık gelen sınıfı bulup object'e değer ataması yapacağız.
        public GenericRepository()
        {
            //cotr metodudur.
            _object=c.Set<T>(); //context'e bağlı olarak gönderilen T değeridir. yeni değeri.
        }
        public void Delete(T p)
        {
            var deletedEntity=c.Entry(p); //Entity State üzerinden silme işlemi
            deletedEntity.State=EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //bir dizide veya listede 1 tane değer göndermek için kullanılır. Id'si 1 olan gibi tek değer döndürür.
        }
        public void Insert(T p)
        {
            var addedEntity = c.Entry(p); //entity state üzerinden ekleme işlemi
            addedEntity.State= EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();   
        }
        public List<T> List()
        {
            return _object.ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
           return _object.Where(filter).ToList(); //filterden gelen değere göre lsiteleme yapacak.
        }
        public void Update(T p)
        {
            var deletedEntity=c.Entry(p);
            deletedEntity.State= EntityState.Modified;
            c.SaveChanges();
        }
    }
}
