using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        //parametreli listeleme yapacağız.
        List<Content> GetListByTitleID(int id); //Id'ye göre tüm listeyi döndür. başlığa göre içerik getirme işlemi
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id); 
        Content GetByID(int id);
        void ContentAdd(Content content);
        void ContentUpdate(Content content);
        void ContentDelete(Content content);
    }
}
