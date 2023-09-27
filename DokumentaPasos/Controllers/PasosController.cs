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
    public class PasosController : Controller
    {
        private LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: Pasos
        public ActionResult Index()
        {
            var pasos = db.Pasos.Include(p => p.Gradjanin).Include(p => p.InformacijeOPasosu).Include(p => p.IzgubljenPaso).Include(p => p.MaloletnoLouse).Include(p => p.Uplata);
            return View(pasos.ToList());
        }

        // GET: Pasos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paso paso = db.Pasos.Find(id);
            if (paso == null)
            {
                return HttpNotFound();
            }
            return View(paso);
        }

        // GET: Pasos/Create
        public ActionResult Create()
        {
            ViewBag.GradjaninID = new SelectList(db.Gradjanins, "GradjaninID", "BrojDokumenta");
            ViewBag.InformacijeOPasosuID = new SelectList(db.InformacijeOPasosus, "InformacijeOPasosuID", "Email");
            ViewBag.IzgubljenPasosID = new SelectList(db.IzgubljenPasos, "IzgubljenPasosID", "PrijavaNestanka");
            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID", "SaglasnostRoditelja");
            ViewBag.UplataID = new SelectList(db.Uplatas, "UplataID", "ObrzacPutneIsprave");
            return View();
        }

        // POST: Pasos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PasosID,IzdajePU,Drzava,Telefon,InformacijeOPasosuID,UplataID,GradjaninID,MaloletnoLiceID,IzgubljenPasosID,TipDokumenta")] Paso paso)
        {
            if (ModelState.IsValid)
            {
                db.Pasos.Add(paso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GradjaninID = new SelectList(db.Gradjanins, "GradjaninID", "BrojDokumenta", paso.GradjaninID);
            ViewBag.InformacijeOPasosuID = new SelectList(db.InformacijeOPasosus, "InformacijeOPasosuID", "Email", paso.InformacijeOPasosuID);
            ViewBag.IzgubljenPasosID = new SelectList(db.IzgubljenPasos, "IzgubljenPasosID", "PrijavaNestanka", paso.IzgubljenPasosID);
            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID", "SaglasnostRoditelja", paso.MaloletnoLiceID);
            ViewBag.UplataID = new SelectList(db.Uplatas, "UplataID", "ObrzacPutneIsprave", paso.UplataID);
            return View(paso);
        }

        // GET: Pasos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paso paso = db.Pasos.Find(id);
            if (paso == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradjaninID = new SelectList(db.Gradjanins, "GradjaninID", "BrojDokumenta", paso.GradjaninID);
            ViewBag.InformacijeOPasosuID = new SelectList(db.InformacijeOPasosus, "InformacijeOPasosuID", "Email", paso.InformacijeOPasosuID);
            ViewBag.IzgubljenPasosID = new SelectList(db.IzgubljenPasos, "IzgubljenPasosID", "PrijavaNestanka", paso.IzgubljenPasosID);
            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID", "SaglasnostRoditelja", paso.MaloletnoLiceID);
            ViewBag.UplataID = new SelectList(db.Uplatas, "UplataID", "ObrzacPutneIsprave", paso.UplataID);
            return View(paso);
        }

        // POST: Pasos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PasosID,IzdajePU,Drzava,Telefon,InformacijeOPasosuID,UplataID,GradjaninID,MaloletnoLiceID,IzgubljenPasosID,TipDokumenta")] Paso paso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradjaninID = new SelectList(db.Gradjanins, "GradjaninID", "BrojDokumenta", paso.GradjaninID);
            ViewBag.InformacijeOPasosuID = new SelectList(db.InformacijeOPasosus, "InformacijeOPasosuID", "Email", paso.InformacijeOPasosuID);
            ViewBag.IzgubljenPasosID = new SelectList(db.IzgubljenPasos, "IzgubljenPasosID", "PrijavaNestanka", paso.IzgubljenPasosID);
            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID", "SaglasnostRoditelja", paso.MaloletnoLiceID);
            ViewBag.UplataID = new SelectList(db.Uplatas, "UplataID", "ObrzacPutneIsprave", paso.UplataID);
            return View(paso);
        }

        // GET: Pasos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paso paso = db.Pasos.Find(id);
            if (paso == null)
            {
                return HttpNotFound();
            }
            return View(paso);
        }

        // POST: Pasos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paso paso = db.Pasos.Find(id);
            db.Pasos.Remove(paso);
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
