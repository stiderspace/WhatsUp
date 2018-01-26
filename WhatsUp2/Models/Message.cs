using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WhatsUp2.Models
{
    [Table("Messages")]
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public String Messages { get; set; }
        public DateTime SendDate { get; set; }

        public virtual Account Sender { get; set; }
        public virtual Chat Chat { get; set; }
    }
}