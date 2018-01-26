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
        public ActionResult Index()
        {
            IEnumerable<Chat> allChats = ((Account)Session["loggedin_account"]).Chats;
            return View(allChats);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Leave()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Send()
        {
            return RedirectToAction("Index");
        }


    }
}