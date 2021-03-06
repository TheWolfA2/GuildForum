﻿using GuildForum.Models;
using GuildForum.Areas.Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownDeep;

namespace GuildForum.Areas.Forum.Controllers
{
    public class ForumsController : Controller
    {
        protected ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Forums
        public ActionResult Index()
        {
            List<ForumSection> forumSections = _db.ForumSections.ToList();
            return View(forumSections);
        }

        public ActionResult Threads(int id)
        {
            Models.Forum forum = _db.Forums.Find(id);
            if (forum == null)
            {
                // TODO: Handle no forum with given id
            }
            return View(new ThreadListModel(forum));
        }

        public ActionResult NewThread(int id)
        {
            Models.Forum forum = _db.Forums.Find(id);
            if (forum == null)
            {
                // TODO: Handle invalid forum id
            }
            ViewBag.ForumId = id;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult NewThread(Thread t, int id)
        {
            Markdown markdown = new Markdown() { SafeMode = true };
            t.Content = markdown.Transform(t.Content);
            return View(t);
        }
    }
}