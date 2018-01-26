using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUp2.Models;
using WhatsUp2.Controllers;
using WhatsUp2.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUp2.Models
{
    [Table("Chat")]
    public class Chat
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }
        public string ChatDesc { get; set; }

        //navigational properties
        public virtual ICollection<Account> Participants { get; set; }
        public virtual ICollection<Message> Messages { get; set; }


    }
}