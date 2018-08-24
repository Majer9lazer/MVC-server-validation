using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using MVC_validation_on_server.Models;

namespace MVC_validation_on_server.Controllers
{
    public class FeedbacksController : Controller
    {
        private ServerValidation_DbEntities db = new ServerValidation_DbEntities();

        // GET: Feedbacks
        public ActionResult Index()
        {
            var feedbacks = db.Feedbacks.Include(f => f.MessageTheme);
            return View(feedbacks.ToList());
        }

        // GET: Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            try
            {
                if (db.MessageThemes.Count() < 5)
                {
                    db.MessageThemes.AddRange(new[]
                    {
                        new MessageTheme("Вопросы общего характера"),
                        new MessageTheme("Жалобы и предложения"),
                        new MessageTheme("Замечания и предложения по работе сайта"),
                        new MessageTheme("Поиск отправления"),
                        new MessageTheme("Финансовые вопросы"),
                    });
                    db.SaveChanges();
                }
               
            }
            catch (Exception)
            {
                // ignored
            }

            var appsettings = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            ViewBag.MessageThemeId = new SelectList(db.MessageThemes, "MessageThemeId", "ThemeName");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,MessageThemeId,Question")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageThemeId = new SelectList(db.MessageThemes, "MessageThemeId", "ThemeName", feedback.MessageThemeId);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageThemeId = new SelectList(db.MessageThemes, "MessageThemeId", "ThemeName", feedback.MessageThemeId);
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,MessageThemeId,Question")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageThemeId = new SelectList(db.MessageThemes, "MessageThemeId", "ThemeName", feedback.MessageThemeId);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
