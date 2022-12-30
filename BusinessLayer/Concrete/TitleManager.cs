using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TitleManager : ITitleService
    {
        ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        //yapıcı bir metod gerekiyor.
        public Title GetByID(int id)
        {
            return _titleDal.Get(x => x.TitleID == id);
        }
        public List<Title> GetList()
        {
            return _titleDal.List();
        }

        public List<Title> GetListByWriter(int id)
        {
            return _titleDal.List(x => x.WriterID == id);
        }

        public void TitleAddBL(Title title)
        {
            _titleDal.Insert(title);
        }

        public void TitleDeleteBL(Title title)
        {
            _titleDal.Update(title);
        }

        public void TitleUpdateBL(Title title)
        {
            _titleDal.Update(title);
        }
    }
}
