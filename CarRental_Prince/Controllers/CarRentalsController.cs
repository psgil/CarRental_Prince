using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRental_Prince.Models;

namespace CarRental_Prince.Controllers
{
    public class CarRental_PrincesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This  method is used to show car rental list
        // GET: CarRental_Princes
        public ActionResult Index()
        {
            var CarRental_Princes = db.CarRental_Princes.Include(c => c.Cars).Include(c => c.Customers);
            return View(CarRental_Princes.ToList());
        }
        //This  method is used to show car rental detail of selected car
        // GET: CarRental_Princes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental_Prince.Models.CarRental_Prince CarRental_Prince = db.CarRental_Princes.Find(id);
            if (CarRental_Prince == null)
            {
                return HttpNotFound();
            }
            return View(CarRental_Prince);
        }

        //This  method is used to show car view
        // GET: CarRental_Princes/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName");
            return View();
        }
        //This  method is used to add car rental record
        // POST: CarRental_Princes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,CarID,IssueDate,DueDate,ReturnDate")] CarRental_Prince.Models.CarRental_Prince CarRental_Prince)
        {
            if (ModelState.IsValid)
            {
                db.CarRental_Princes.Add(CarRental_Prince);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName", CarRental_Prince.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", CarRental_Prince.CustomerID);
            return View(CarRental_Prince);
        }

        // GET: CarRental_Princes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental_Prince.Models.CarRental_Prince CarRental_Prince = db.CarRental_Princes.Find(id);
            if (CarRental_Prince == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName", CarRental_Prince.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", CarRental_Prince.CustomerID);
            return View(CarRental_Prince);
        }
        //This  method is used to edit car rental record
        // POST: CarRental_Princes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,CarID,IssueDate,DueDate,ReturnDate")] CarRental_Prince.Models.CarRental_Prince CarRental_Prince)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CarRental_Prince).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "CarName", CarRental_Prince.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", CarRental_Prince.CustomerID);
            return View(CarRental_Prince);
        }
        //This  method is used to delete car rental record
        // GET: CarRental_Princes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental_Prince.Models.CarRental_Prince CarRental_Prince = db.CarRental_Princes.Find(id);
            if (CarRental_Prince == null)
            {
                return HttpNotFound();
            }
            return View(CarRental_Prince);
        }

        // POST: CarRental_Princes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRental_Prince.Models.CarRental_Prince CarRental_Prince = db.CarRental_Princes.Find(id);
            db.CarRental_Princes.Remove(CarRental_Prince);
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
