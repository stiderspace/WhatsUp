using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WhatsUp2.Models
{
    public class WhatsUp2Context : DbContext
    {
        public WhatsUp2Context() : base("name=WhatsUp2Context")
        {
        }

        public System.Data.Entity.DbSet<WhatsUp2.Models.Contact> Contacts { get; set; }
        public System.Data.Entity.DbSet<WhatsUp2.Models.Account> Accounts { get; set; }
        public System.Data.Entity.DbSet<WhatsUp2.Models.Chat> Chats { get; set; }
        public System.Data.Entity.DbSet<WhatsUp2.Models.Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            // account heeft meerdere contacten
            modelbuilder.Entity<Contact>().HasOptional<Account>(c => c.ContactAccount)
               .WithMany(a => a.Contacts)
               .HasForeignKey<int?>(c => c.ContactAccountId).WillCascadeOnDelete(false);
        }
    }
}
