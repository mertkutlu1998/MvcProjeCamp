using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p); //Admin message kısmı
        List<Message> GetListSendbox(string p);
        Message GetByID(int id);
        void MessageAddBL(Message message);
        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
    }
}
