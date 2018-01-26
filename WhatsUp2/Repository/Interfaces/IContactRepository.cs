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
    interface IContactRepository
    {
        int GetAccountId(string PhoneNumber);

        IEnumerable<Contact> GetContact();
        IEnumerable<Contact> GetAllContacts(int accountId);
        Contact GetContactBy(int contactId);

        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
    }
}
