using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTAMA.Models;

namespace ProjectTAMA.Controllers
{
    public class PlaceTablesController : Controller
    {
        private PlacesInfoDatabaseEntities db = new PlacesInfoDatabaseEntities();

        // GET: PlaceTables
        public ActionResult Index()
        {
            return View(db.PlaceTables.ToList());
        }

        // GET: PlaceTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceTable placeTable = db.PlaceTables.Find(id);
            if (placeTable == null)
            {
                return HttpNotFound();
            }
            return View(placeTable);
        }

        // GET: PlaceTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceID,PlaceName,PlaceDescription,PlaceImage")] PlaceTable placeTable)
        {
            if (ModelState.IsValid)
            {
                db.PlaceTables.Add(placeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placeTable);
        }

        // GET: PlaceTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceTable placeTable = db.PlaceTables.Find(id);
            if (placeTable == null)
            {
                return HttpNotFound();
            }
            return View(placeTable);
        }

        // POST: PlaceTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceID,PlaceName,PlaceDescription,PlaceImage")] PlaceTable placeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placeTable);
        }

        // GET: PlaceTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceTable placeTable = db.PlaceTables.Find(id);
            if (placeTable == null)
            {
                return HttpNotFound();
            }
            return View(placeTable);
        }

        // POST: PlaceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceTable placeTable = db.PlaceTables.Find(id);
            db.PlaceTables.Remove(placeTable);
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
