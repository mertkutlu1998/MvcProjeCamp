using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        DbSet<Category> _object;
        public void Delete(Category category)
        {
            _object.Remove(category);
            c.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category category)
        {
            _object.Add(category);
            c.SaveChanges(); //context'deki c'dir.
        }

        public List<Category> List()
        {
            return _object.ToList(); //listeleme _objects'den gelenleri entity frameworkda kullanılan metot tolist
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            c.SaveChanges();
        }
    }
}