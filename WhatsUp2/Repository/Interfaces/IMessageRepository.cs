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
    interface IMessageRepository
    {
        IEnumerable<Message> GetMessagesFromChat(int ChatId);
    }
}
