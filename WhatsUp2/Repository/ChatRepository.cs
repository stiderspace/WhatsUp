using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUp2.Models;
using WhatsUp2.Controllers;
using WhatsUp2.Repository;

namespace WhatsUp2.Repository
{
    public class ChatRepository : IChatRepository
    {
        private WhatsUp2Context db = new WhatsUp2Context();

        public void AddMember(Contact contact)
        {
            //       db.Groups.Add(contact);
            db.SaveChanges();
        }

        public void CreateChat(Chat chat)
        {
            db.Chats.Add(chat);
            db.SaveChanges();
        }


        public IEnumerable<Contact> GetAllChats(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(int id)
        {
            Account account = db.Accounts.Where(A => A.Id == id).FirstOrDefault();
            return account;
        }

        public void addMessage(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }

        public void addMember(Chat chat)
        {

        }

        public Chat getChatById(int chatId)
        {
            Chat chat = db.Chats.Find(chatId);
            return chat;
        }

        public int CreatePrivateChat(Chat chat)
        {
            db.Chats.Add(chat);
            db.SaveChanges();
            int chatId = db.Chats.Where(C => C.ChatName == chat.ChatName).FirstOrDefault().ChatId;

            return chatId;
        }
    }
}