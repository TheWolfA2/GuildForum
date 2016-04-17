using GuildForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildForum.Controllers
{
    public class ForumsController : Controller
    {
        protected ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Forums
        public ActionResult Index()
        {
            ForumIndexModel model = new ForumIndexModel();
            model.ForumSections = _db.ForumSections.ToList();
            return View(model);
        }
    }
}