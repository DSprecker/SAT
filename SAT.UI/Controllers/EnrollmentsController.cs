using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.DATA.EF;

namespace SAT.UI.Controllers
{
    public class EnrollmentsController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Enrollments
        [Authorize(Roles = "Admin, Scheduling")]
        public ActionResult Index()
        {
            var enrollments1 = db.Enrollments1.Include(e => e.ScheduledClass).Include(e => e.Student);
            return View(enrollments1.ToList());
        }

        // GET: Enrollments/Details/5
        [Authorize(Roles = "Admin, Scheduling")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollments enrollments = db.Enrollments1.Find(id);
            if (enrollments == null)
            {
                return HttpNotFound();
            }
            return View(enrollments);
        }

        // GET: Enrollments/Create
        [Authorize(Roles = "Admin, Scheduling")]

        public ActionResult Create()
        {
            ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses1, "ScheduledClassId", "ShortDesc");
            ViewBag.StudentId = new SelectList(db.Students1, "StudentId", "FullName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Scheduling")]

        public ActionResult Create([Bind(Include = "EnrollmentId,StudentId,ScheduledClassId,EnrollmentDate")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments1.Add(enrollments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses1, "ScheduledClassId", "ShortDesc", enrollments.ScheduledClassId);
            ViewBag.StudentId = new SelectList(db.Students1, "StudentId", "FullName", enrollments.StudentId);
            return View(enrollments);
        }

        // GET: Enrollments/Edit/5
        [Authorize(Roles = "Admin, Scheduling")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollments enrollments = db.Enrollments1.Find(id);
            if (enrollments == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses1, "ScheduledClassId", "InstructorName", enrollments.ScheduledClassId);
            ViewBag.StudentId = new SelectList(db.Students1, "StudentId", "FirstName", enrollments.StudentId);
            return View(enrollments);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Scheduling")]

        public ActionResult Edit([Bind(Include = "EnrollmentId,StudentId,ScheduledClassId,EnrollmentDate")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScheduledClassId = new SelectList(db.ScheduledClasses1, "ScheduledClassId", "InstructorName", enrollments.ScheduledClassId);
            ViewBag.StudentId = new SelectList(db.Students1, "StudentId", "FirstName", enrollments.StudentId);
            return View(enrollments);
        }

        // GET: Enrollments/Delete/5
        [Authorize(Roles = "Admin, Scheduling")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollments enrollments = db.Enrollments1.Find(id);
            if (enrollments == null)
            {
                return HttpNotFound();
            }
            return View(enrollments);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Scheduling")]

        public ActionResult DeleteConfirmed(int id)
        {
            Enrollments enrollments = db.Enrollments1.Find(id);
            db.Enrollments1.Remove(enrollments);
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
