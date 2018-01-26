using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUp2.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }

        public int OwnerAccountId { get; set; }
        public virtual Account OwnerAccount { get; set; } // navigation property

        public int? ContactAccountId { get; set; }
        public virtual Account ContactAccount { get; set; } // navigation property
    }
}