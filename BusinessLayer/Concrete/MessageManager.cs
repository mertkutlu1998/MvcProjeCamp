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
    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x=>x.MessageID==id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x=>x.Receiver== p); //alıcı
        }
        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.Sender == p); //gönderici mail
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDeleteBL(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdateBL(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
