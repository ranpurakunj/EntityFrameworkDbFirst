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
    public class tbl_User_TableController : Controller
    {
        private EmployeeDatabaseEntities1 db = new EmployeeDatabaseEntities1();

        // GET: tbl_User_Table
        public ActionResult Index()
        {
            return View(db.tbl_User_Table.ToList());
        }

        // GET: tbl_User_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User_Table user_table = db.tbl_User_Table.Find(id);
            if (user_table == null)
            {
                return HttpNotFound();
            }
            return View(user_table);
        }

        // GET: tbl_User_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_User_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_Id,Username,Password,User_Full_Name,Last_Login_on,Active_status")] tbl_User_Table tbl_User_Table)
        {
            if (ModelState.IsValid)
            {
                db.tbl_User_Table.Add(tbl_User_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_User_Table);
        }

        // GET: tbl_User_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User_Table tbl_User_Table = db.tbl_User_Table.Find(id);
            if (tbl_User_Table == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User_Table);
        }

        // POST: tbl_User_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_Id,Username,Password,User_Full_Name,Last_Login_on,Active_status")] tbl_User_Table tbl_User_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_User_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_User_Table);
        }

        // GET: tbl_User_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User_Table tbl_User_Table = db.tbl_User_Table.Find(id);
            if (tbl_User_Table == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User_Table);
        }

        // POST: tbl_User_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_User_Table tbl_User_Table = db.tbl_User_Table.Find(id);
            db.tbl_User_Table.Remove(tbl_User_Table);
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
