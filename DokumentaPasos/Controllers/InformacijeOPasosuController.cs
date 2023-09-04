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
    public class InformacijeOPasosuController : Controller
    {
        private readonly LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: InformacijeOPasosu
        public ActionResult Index()
        {
            var informacijeOPasosus = db.InformacijeOPasosus.Include(i => i.IzdavanjePasosa).Include(i => i.ProduzetakPasosa);
            return View(informacijeOPasosus.ToList());
        }

        // GET: InformacijeOPasosu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacijeOPasosu informacijeOPasosu = db.InformacijeOPasosus.Find(id);
            if (informacijeOPasosu == null)
            {
                return HttpNotFound();
            }
            return View(informacijeOPasosu);
        }

        // GET: InformacijeOPasosu/Create
        public ActionResult Create()
        {
            ViewBag.IzdavanjePasosaID = new SelectList(db.IzdavanjePasosas, "IzdavanjePasosaID", "IzvodMaticneKnjigeRodjenih");
            ViewBag.ProduzetakPasosaID = new SelectList(db.ProduzetakPasosas, "ProduzetekPasosaID", "LicnaKarta");
            return View();
        }

        // POST: InformacijeOPasosu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformacijeOPasosuID,Email,IzdavanjePasosaID,ProduzetakPasosaID")] InformacijeOPasosu informacijeOPasosu)
        {
            if (ModelState.IsValid)
            {
                db.InformacijeOPasosus.Add(informacijeOPasosu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IzdavanjePasosaID = new SelectList(db.IzdavanjePasosas, "IzdavanjePasosaID", "IzvodMaticneKnjigeRodjenih", informacijeOPasosu.IzdavanjePasosaID);
            ViewBag.ProduzetakPasosaID = new SelectList(db.ProduzetakPasosas, "ProduzetekPasosaID", "LicnaKarta", informacijeOPasosu.ProduzetakPasosaID);
            return View(informacijeOPasosu);
        }

        // GET: InformacijeOPasosu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacijeOPasosu informacijeOPasosu = db.InformacijeOPasosus.Find(id);
            if (informacijeOPasosu == null)
            {
                return HttpNotFound();
            }
            ViewBag.IzdavanjePasosaID = new SelectList(db.IzdavanjePasosas, "IzdavanjePasosaID", "IzvodMaticneKnjigeRodjenih", informacijeOPasosu.IzdavanjePasosaID);
            ViewBag.ProduzetakPasosaID = new SelectList(db.ProduzetakPasosas, "ProduzetekPasosaID", "LicnaKarta", informacijeOPasosu.ProduzetakPasosaID);
            return View(informacijeOPasosu);
        }

        // POST: InformacijeOPasosu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformacijeOPasosuID,Email,IzdavanjePasosaID,ProduzetakPasosaID")] InformacijeOPasosu informacijeOPasosu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacijeOPasosu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IzdavanjePasosaID = new SelectList(db.IzdavanjePasosas, "IzdavanjePasosaID", "IzvodMaticneKnjigeRodjenih", informacijeOPasosu.IzdavanjePasosaID);
            ViewBag.ProduzetakPasosaID = new SelectList(db.ProduzetakPasosas, "ProduzetekPasosaID", "LicnaKarta", informacijeOPasosu.ProduzetakPasosaID);
            return View(informacijeOPasosu);
        }

        // GET: InformacijeOPasosu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacijeOPasosu informacijeOPasosu = db.InformacijeOPasosus.Find(id);
            if (informacijeOPasosu == null)
            {
                return HttpNotFound();
            }
            return View(informacijeOPasosu);
        }

        // POST: InformacijeOPasosu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformacijeOPasosu informacijeOPasosu = db.InformacijeOPasosus.Find(id);
            db.InformacijeOPasosus.Remove(informacijeOPasosu);
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
