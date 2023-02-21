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
    public class Employee_masterController : Controller
    {
        private EmployeeDatabaseEntities1 db = new EmployeeDatabaseEntities1();

        // GET: Employee_master
        public ActionResult Index()
        {
            return View(db.Employee_master.ToList());
        }

        // GET: Employee_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_master employee_master = db.Employee_master.Find(id);
            if (employee_master == null)
            {
                return HttpNotFound();
            }
            return View(employee_master);
        }

        // GET: Employee_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee_master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_Id,Employee_Name,Contact_No,Email,Address_Line1,Address_Line2,City,State,Country,Zip_Code,Active_Status")] Employee_master employee_master)
        {
            if (ModelState.IsValid)
            {
                db.Employee_master.Add(employee_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee_master);
        }

        // GET: Employee_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_master employee_master = db.Employee_master.Find(id);
            if (employee_master == null)
            {
                return HttpNotFound();
            }
            return View(employee_master);
        }

        // POST: Employee_master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_Id,Employee_Name,Contact_No,Email,Address_Line1,Address_Line2,City,State,Country,Zip_Code,Active_Status")] Employee_master employee_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee_master);
        }

        // GET: Employee_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_master employee_master = db.Employee_master.Find(id);
            if (employee_master == null)
            {
                return HttpNotFound();
            }
            return View(employee_master);
        }

        // POST: Employee_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_master employee_master = db.Employee_master.Find(id);
            db.Employee_master.Remove(employee_master);
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
