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

        public Contact GetContactBy(int contactId)
        {
            Contact contact = db.Contacts.Find(contactId);
            return contact;
        }

        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}