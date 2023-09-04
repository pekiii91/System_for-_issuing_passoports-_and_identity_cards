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
    public class ProduzetakPasosaController : Controller
    {
        private readonly LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: ProduzetakPasosa
        public ActionResult Index()
        {
            return View(db.ProduzetakPasosas.ToList());
        }

        // GET: ProduzetakPasosa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduzetakPasosa produzetakPasosa = db.ProduzetakPasosas.Find(id);
            if (produzetakPasosa == null)
            {
                return HttpNotFound();
            }
            return View(produzetakPasosa);
        }

        // GET: ProduzetakPasosa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduzetakPasosa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProduzetekPasosaID,StariPasos,TroskoviUplate")] ProduzetakPasosa produzetakPasosa)
        {
            if (ModelState.IsValid)
            {
                db.ProduzetakPasosas.Add(produzetakPasosa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produzetakPasosa);
        }

        // GET: ProduzetakPasosa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduzetakPasosa produzetakPasosa = db.ProduzetakPasosas.Find(id);
            if (produzetakPasosa == null)
            {
                return HttpNotFound();
            }
            return View(produzetakPasosa);
        }

        // POST: ProduzetakPasosa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProduzetekPasosaID,StariPasos,TroskoviUplate")] ProduzetakPasosa produzetakPasosa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produzetakPasosa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produzetakPasosa);
        }

        // GET: ProduzetakPasosa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduzetakPasosa produzetakPasosa = db.ProduzetakPasosas.Find(id);
            if (produzetakPasosa == null)
            {
                return HttpNotFound();
            }
            return View(produzetakPasosa);
        }

        // POST: ProduzetakPasosa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProduzetakPasosa produzetakPasosa = db.ProduzetakPasosas.Find(id);
            db.ProduzetakPasosas.Remove(produzetakPasosa);
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
