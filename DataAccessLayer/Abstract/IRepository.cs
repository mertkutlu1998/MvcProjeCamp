using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> //type gönderiyoruz bir entity'i karşılayacak.
    {
        //Bütün tablolar için Dal açmadan kod fazlalığı yapmadan DRY yapısını kullanayarak IRepository oluşturup typini T yaparak oluşturabilir.Btüün tablolar için interface kullanmamıza gerek kalmadı.
        List<T> List();
        void Insert(T p); //p dediğimiz <Category> category yani küçük değişken ismimiz.
        T Get(Expression<Func<T, bool>> filter); //T entity anlamına geliyor.
        void Delete(T p);
        void Update(T p);
        //Şimdi bir öğe ekleyeceğiz

        List<T> List(Expression<Func<T, bool>> filter); //şartlı listeleme yapıcak ne istersek onu getirecek örneğin sadece yazar adı ali olanları getireceğiz.
    }
}
