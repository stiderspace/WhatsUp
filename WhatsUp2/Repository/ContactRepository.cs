using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp2.Models;
using WhatsUp2.Controllers;
using WhatsUp2.Repository;

namespace WhatsUp2.Repository
{
    public class ContactRepository : IContactRepository
    {
        private WhatsUp2Context db = new WhatsUp2Context();

        public int GetAccountId(string PhoneNumber)
        {
            Account account = db.Accounts.Where(a => a.PhoneNumber == PhoneNumber).FirstOrDefault();
            if (account != null)
                return account.Id;
            else
                return 0;
        }

        public IEnumerable<Contact> GetContact()
        {
            IEnumerable<Contact> contacts = db.Contacts;
            return contacts;
        }

        public IEnumerable<Contact> GetAllContacts(int accountid)
        {
            IEnumerable<Contact> myContacts = db.Contacts.Where(c => c.OwnerAccountId == accountid);
            return myContacts;
        }

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