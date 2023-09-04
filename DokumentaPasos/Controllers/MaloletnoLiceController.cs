using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DokumentaPasos.Models;

namespace DokumentaPasos.Controllers
{
    public class MaloletnoLiceController : Controller
    {
        private readonly LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: MaloletnoLice
        public ActionResult Index()
        {
            return View(db.MaloletnoLice.ToList());
        }

        // GET: MaloletnoLice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaloletnoLouse maloletnoLouse = db.MaloletnoLice.Find(id);
            if (maloletnoLouse == null)
            {
                return HttpNotFound();
            }
            return View(maloletnoLouse);
        }

        // GET: MaloletnoLice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaloletnoLice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaloletnoLiceID,UverenjeODrzavljanstvu,IzvodMaticneKnjigeRodjenih,UplaceneNaknade,SaglasnostRoditelja,Fotografija,RokVazenja")] MaloletnoLouse maloletnoLouse)
        {
            if (ModelState.IsValid)
            {
                db.MaloletnoLice.Add(maloletnoLouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maloletnoLouse);
        }

        // GET: MaloletnoLice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaloletnoLouse maloletnoLouse = db.MaloletnoLice.Find(id);
            if (maloletnoLouse == null)
            {
                return HttpNotFound();
            }
            return View(maloletnoLouse);
        }

        // POST: MaloletnoLice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaloletnoLiceID,UverenjeODrzavljanstvu,IzvodMaticneKnjigeRodjenih,UplaceneNaknade,SaglasnostRoditelja,Fotografija,RokVazenja")] MaloletnoLouse maloletnoLouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maloletnoLouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maloletnoLouse);
        }

        // GET: MaloletnoLice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaloletnoLouse maloletnoLouse = db.MaloletnoLice.Find(id);
            if (maloletnoLouse == null)
            {
                return HttpNotFound();
            }
            return View(maloletnoLouse);
        }

        // POST: MaloletnoLice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaloletnoLouse maloletnoLouse = db.MaloletnoLice.Find(id);
            db.MaloletnoLice.Remove(maloletnoLouse);
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
