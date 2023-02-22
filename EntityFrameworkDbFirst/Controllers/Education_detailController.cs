using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkDbFirst;

namespace EntityFrameworkDbFirst.Controllers
{
    public class Education_detailController : Controller
    {
        private EmployeeDatabaseEntities1 db = new EmployeeDatabaseEntities1();

        // GET: Education_detail
        public ActionResult Index()
        {
            var education_detail = db.Education_detail.Include(e => e.Employee_master);
            return View(education_detail.ToList());
        }

        // GET: Education_detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education_detail education_detail = db.Education_detail.Find(id);
            if (education_detail == null)
            {
                return HttpNotFound();
            }
            return View(education_detail);
        }

        // GET: Education_detail/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.Employee_master, "Employee_Id", "Employee_Name");
            return View();
        }

        // POST: Education_detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Education_detail_id,Employee_ID,Education,University,Grade_Obtained,Passing_Year,Active_status")] Education_detail education_detail)
        {
            if (ModelState.IsValid)
            {
                db.Education_detail.Add(education_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.Employee_master, "Employee_Id", "Employee_Name", education_detail.Employee_ID);
            return View(education_detail);
        }

        // GET: Education_detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education_detail education_detail = db.Education_detail.Find(id);
            if (education_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.Employee_master, "Employee_Id", "Employee_Name", education_detail.Employee_ID);
            return View(education_detail);
        }

        // POST: Education_detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Education_detail_id,Employee_ID,Education,University,Grade_Obtained,Passing_Year,Active_status")] Education_detail education_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.Employee_master, "Employee_Id", "Employee_Name", education_detail.Employee_ID);
            return View(education_detail);
        }

        // GET: Education_detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education_detail education_detail = db.Education_detail.Find(id);
            if (education_detail == null)
            {
                return HttpNotFound();
            }
            return View(education_detail);
        }

        // POST: Education_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Education_detail education_detail = db.Education_detail.Find(id);
            db.Education_detail.Remove(education_detail);
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
