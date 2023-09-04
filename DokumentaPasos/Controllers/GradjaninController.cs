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
    public class GradjaninController : Controller
    {
        private readonly LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: Gradjanin
        public ActionResult Index()
        {
            var gradjanins = db.Gradjanins.Include(g => g.MaloletnoLouse);
            return View(gradjanins.ToList());
        }

        // GET: Gradjanin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gradjanin gradjanin = db.Gradjanins.Find(id);
            if (gradjanin == null)
            {
                return HttpNotFound();
            }
            return View(gradjanin);
        }

        // GET: Gradjanin/Create
        public ActionResult Create()
        {
            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID", "UverenjeODrzavljanstvu");
            return View();
        }

        // POST: Gradjanin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradjaninID,Tip,Ime,Prezime,JMBG," +
            "Pol,DatumIzdavanja,DatumRodjenja,MestoRodjenja," +
            "Prebivaliste,KodDrzave,MaloletnoLiceID,VaziDo")] Gradjanin gradjanin)
        {
            if (ModelState.IsValid)
            {
                db.Gradjanins.Add(gradjanin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID",
                "UverenjeODrzavljanstvu", gradjanin.MaloletnoLiceID);

            return View(gradjanin);

        }

        // GET: Gradjanin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gradjanin gradjanin = db.Gradjanins.Find(id);
            if (gradjanin == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID", 
                "UverenjeODrzavljanstvu", gradjanin.MaloletnoLiceID);
            return View(gradjanin);
        }

        // POST: Gradjanin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradjaninID,Tip,Ime,Prezime,JMBG,Pol," +
            "DatumIzdavanja,DatumRodjenja,MestoRodjenja,Prebivaliste,KodDrzave," +
            "MaloletnoLiceID,VaziDo")] Gradjanin gradjanin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradjanin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaloletnoLiceID = new SelectList(db.MaloletnoLice, "MaloletnoLiceID", 
                "UverenjeODrzavljanstvu", gradjanin.MaloletnoLiceID);
            return View(gradjanin);
        }

        // GET: Gradjanin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gradjanin gradjanin = db.Gradjanins.Find(id);
            if (gradjanin == null)
            {
                return HttpNotFound();
            }
            return View(gradjanin);
        }

        // POST: Gradjanin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gradjanin gradjanin = db.Gradjanins.Find(id);
            db.Gradjanins.Remove(gradjanin);
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
