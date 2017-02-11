using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelReviewProject.Models;

namespace TravelReviewProject.Controllers
{
    public class ReviewModelsController : Controller
    {
        private TravelReviewProjectContext db = new TravelReviewProjectContext();

        // GET: ReviewModels
        public ActionResult Index()
        {
            var reviewModels = db.ReviewModels.Include(r => r.Category);
            return View(reviewModels.ToList());
        }

        // GET: ReviewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModel reviewModel = db.ReviewModels.Find(id);
            if (reviewModel == null)
            {
                return HttpNotFound();
            }
            return View(reviewModel);
        }

        // GET: ReviewModels/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CategoryModels, "CategoryID", "Name");
            return View();
        }

        // POST: ReviewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Summary,Title,Comment,Location,PublishDate,VacationStart,VacationEnd,CategoryID")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                db.ReviewModels.Add(reviewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryModels, "CategoryID", "Name", reviewModel.CategoryID);
            return View(reviewModel);
        }

        // GET: ReviewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModel reviewModel = db.ReviewModels.Find(id);
            if (reviewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CategoryModels, "CategoryID", "Name", reviewModel.CategoryID);
            return View(reviewModel);
        }

        // POST: ReviewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Summary,Title,Comment,Location,PublishDate,VacationStart,VacationEnd,CategoryID")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CategoryModels, "CategoryID", "Name", reviewModel.CategoryID);
            return View(reviewModel);
        }

        // GET: ReviewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewModel reviewModel = db.ReviewModels.Find(id);
            if (reviewModel == null)
            {
                return HttpNotFound();
            }
            return View(reviewModel);
        }

        // POST: ReviewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewModel reviewModel = db.ReviewModels.Find(id);
            db.ReviewModels.Remove(reviewModel);
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
