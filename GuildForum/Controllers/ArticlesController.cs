using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GuildForum.Models;

namespace GuildForum.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = _db.Articles.Include(a => a.Author).Include(a => a.EditAuthor);
            return View(articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = _db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,SubTitle,Content")] Article article)
        {
            article.AuthorID = User.Identity.GetUserId();
            article.PostDate = DateTime.Now;
            ModelState["AuthorID"].Errors.Clear();
            UpdateModel(article);
            if (ModelState.IsValid)
            {
                _db.Articles.Add(article);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = _db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(_db.Users, "Id", "FullName", article.AuthorID);
            ViewBag.EditAuthorID = new SelectList(_db.Users, "Id", "FullName", article.EditAuthorID);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,SubTitle,Content,PostDate,AuthorID,EditDate,EditAuthorID")] Article article)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(article).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(_db.Users, "Id", "FullName", article.AuthorID);
            ViewBag.EditAuthorID = new SelectList(_db.Users, "Id", "FullName", article.EditAuthorID);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = _db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = _db.Articles.Find(id);
            _db.Articles.Remove(article);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
