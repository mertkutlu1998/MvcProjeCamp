using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        //Yapıcı metoda ihtiyacımız var Constructor 
        public CategoryManager(ICategoryDal categoryDal) 
        {
            _categoryDal= categoryDal;
        }
        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDeleteBL(Category category)
        {
            _categoryDal.Delete(category); //bu delete genericrepository'den gelen
        }
        public void CategoryUpdateBL(Category category) 
        {
            _categoryDal.Update(category);
        }
        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id); // id den gelen değere eşit mi değil mi sorgusunu yapıyoruz.
        }
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

    }
}
