using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUp2.Models;
using WhatsUp2.Controllers;
using WhatsUp2.Repository;

namespace WhatsUp2.Models
{
    public interface IChatRepository
    {
        void CreateChat(Chat chat);
        void AddMember(Contact contact);
        IEnumerable<Contact> GetAllChats(int id);
        Account GetAccountById(int id);
        void addMessage(Message message);
        Chat getChatById(int chatId);
        int CreatePrivateChat(Chat chat);
    }
}