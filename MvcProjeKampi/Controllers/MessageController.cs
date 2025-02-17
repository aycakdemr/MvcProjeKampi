﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: Message
        public ActionResult Inbox(String p)
        {
            var value = mm.GetListInbox(p);
            var count = mm.GetListStatusFalse().Count();
            ViewBag.d1 = count;
            return View(value) ;
        }
        public ActionResult Sendbox(String p)
        {
            var value = mm.GetListSendInbox(p);
            return View(value);
        }
        public ActionResult GetInBoxMessagetDetails(int id)
        {
            var value = mm.GetById(id);
            value.Status = true;
            mm.MessageUpdate(value);
            return View(value);
        }
        public ActionResult GetSendBoxMessagetDetails(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(message);
            return View();
        }
    }
}