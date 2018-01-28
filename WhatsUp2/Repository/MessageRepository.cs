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
    public class MessageRepository : IMessageRepository
    {
        private WhatsUp2Context db = new WhatsUp2Context();

        public IEnumerable<Chat> Chats { get { return db.Chats; } }

        public IEnumerable<Message> GetMessagesFromChat(int ChatId)
        {
            IEnumerable<Message> messages = db.Messages.Where(M => M.ChatId == ChatId).ToList();
            return messages;
        }
    }
}