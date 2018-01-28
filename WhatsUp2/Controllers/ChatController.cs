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
    public class ChatController : Controller
    {
        private IChatRepository chatRepository = new ChatRepository();
        private IMessageRepository messageRepository = new MessageRepository();
        private IContactRepository contactRepository = new ContactRepository();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Chat> allChats = ((Account)Session["loggedin_account"]).Chats;
            return View(allChats);
        }
        [Authorize]
        public ActionResult Create()
        {
            IEnumerable<Contact> contacts = contactRepository.GetAllContacts(((Account)Session["loggedin_account"]).Id);
            ViewBag.Contacts = contacts;
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewChatModel newChatModel)
        {
            IEnumerable<Contact> contacts = contactRepository.GetAllContacts(((Account)Session["loggedin_account"]).Id);
            ViewBag.Contacts = contacts;
            if (ModelState.IsValid)
            {
                Chat chat = new Chat();
                chat.ChatName = newChatModel.ChatName;
                chat.ChatDesc = newChatModel.ChatDesc;
                chat.Participants.Add(chatRepository.GetAccountById(newChatModel.participant));
                chat.Participants.Add(chatRepository.GetAccountById(((Account)Session["loggedin_account"]).Id));
                chatRepository.CreateChat(chat);

                return RedirectToAction("Index");
            }
            return View(newChatModel);
        }
        [Authorize]
        public ActionResult Chat(int? chatId, String name)
        {
            IEnumerable<Message> messages = messageRepository.GetMessagesFromChat((int)chatId);
            ViewBag.ChatName = name;
            ViewBag.Messages = messages;
            Message message = new Message();
            message.ChatId = (int)chatId;
            return View(message);
        }
        [Authorize]
        public ActionResult Leave()
        {
            return RedirectToAction("Index");
        }


        [Authorize]
        [HttpPost]
        public ActionResult Chat(Message message)
        {
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                message.SenderId = ((Account)Session["loggedin_account"]).Id;

                chatRepository.addMessage(message);
                return RedirectToAction("Chat", new { chatid = message.ChatId, name = chatRepository.getChatById(message.ChatId) });
            }

            return RedirectToAction("Chat", new { chatid = message.ChatId, name = chatRepository.getChatById(message.ChatId) });
        }


    }
}