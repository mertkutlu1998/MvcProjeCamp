using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{ //diğer entityler içinde bunu yapacağız.
    public interface ICategoryService
    {
        //bir listeleme metodu çağırcaz.
        //Burada İmzamızı atıyoruz.
        List<Category> GetList();

        void CategoryAddBL(Category category);
        Category GetByID(int id); //Şart gibi düşünmek gerek ID ye göre işlem yapılacağını söylüyoruz.
        void CategoryDeleteBL(Category category);
        void CategoryUpdateBL(Category category);
    }
}
