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
    public class AccountRepository : IAccountRepository
    {
        private WhatsUp2Context db = new WhatsUp2Context();
   
        public Account GetAccount(string emailAddress, string password)
        {
            Account account = db.Accounts.Include("Chats").FirstOrDefault(u => u.EmailAddress == emailAddress && u.Password == password);
            return account;
        }
        

        public bool CreateAccount(RegistreerModel model)
        {
            Account account = db.Accounts.Where(a => a.EmailAddress == model.EmailAddress).FirstOrDefault();

            if (account == null)
            {
                account = new Account();
                account.Name = model.Name;
                account.PhoneNumber = model.PhoneNumber;
                account.EmailAddress = model.EmailAddress;
                account.Password = model.Password;
                db.Accounts.Add(account);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteAccount(Account account)
        {
            db.Accounts.Remove(account);
            db.SaveChanges();
        }
        
        public void UpdateAccount(Account account)
        {
            db.Entry(account).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}