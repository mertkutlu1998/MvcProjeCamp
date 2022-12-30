using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        //Cont metod oluşturup istediğimiz interface e ulaşıp atamaları gerçekleştirelim.
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal) //ilgili snıfın yapıcı metodunu oluşturduk.
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAddBL(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDeleteBL(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdateBL(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
