using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhatsUp2.Models;
using WhatsUp2.Repository;
using WhatsUp2.Controllers;

namespace WhatsUp2.Controllers
{
    public class ContactsController : Controller
    {
        private IContactRepository contactRepository = new ContactRepository();
        private IChatRepository chatRepository = new ChatRepository();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Contact> allContacts = contactRepository.GetAllContacts(((Account)Session["loggedin_account"]).Id);

            return View(allContacts);
        }

        // GET: Contacts/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactRepository.GetContactBy((int)id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nickname,PhoneNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.OwnerAccountId = ((Account)Session["loggedin_account"]).Id;
                contact.ContactAccountId = contactRepository.GetAccountId(contact.PhoneNumber.ToString()); //zoeken in db naar iemand met dit nummer
                contactRepository.AddContact(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactRepository.GetContactBy((int)id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nickname,PhoneNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.OwnerAccountId = ((Account)Session["loggedin_account"]).Id;
                contact.ContactAccountId = contactRepository.GetAccountId(contact.PhoneNumber.ToString());
                contactRepository.UpdateContact(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactRepository.GetContactBy((int)id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = contactRepository.GetContactBy((int)id);
            contactRepository.DeleteContact(contact);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult OpenChat(int? id)
        {
            Contact contact = contactRepository.GetContactBy((int)id);
            if (contact.chat == null)
            {
                Chat chat = new Chat();
                chat.ChatName = contact.ContactAccount.Name + contact.OwnerAccount.Name;
                chat.ChatDesc = "private chat";
                chat.Participants.Add(chatRepository.GetAccountById(contact.OwnerAccountId));
                chat.Participants.Add(chatRepository.GetAccountById((int)contact.ContactAccountId));
                int privateChatId = chatRepository.CreatePrivateChat(chat);

                return RedirectToAction("Chat", "Chat", chatRepository.getChatById(privateChatId));
            }
            return RedirectToAction("Chat", "Chat", chatRepository.getChatById((int)contact.chatId));

        }
    }
}
