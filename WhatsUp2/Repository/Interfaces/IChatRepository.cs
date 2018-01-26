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
        int ChatId { get; set; }
        string ChatName { get; set; }
        IEnumerable<Contact> Chatmembers { get; set; }
        void AddMember(Contact contact);
        IEnumerable<Contact> GetAllChats(int id);
    }
}