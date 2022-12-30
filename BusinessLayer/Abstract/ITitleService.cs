using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITitleService
    {
        List<Title> GetList();
        List<Title> GetListByWriter(int id);
        Title GetByID(int id);
        void TitleAddBL(Title title);
        void TitleUpdateBL(Title title);
        void TitleDeleteBL(Title title);
    }
}
