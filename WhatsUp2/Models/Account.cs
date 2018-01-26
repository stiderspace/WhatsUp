using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhatsUp2.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        //navigational properties
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}