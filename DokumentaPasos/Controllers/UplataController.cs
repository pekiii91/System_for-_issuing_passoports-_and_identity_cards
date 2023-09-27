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
    public class UplataController : Controller
    {
        private LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: Uplata
        public ActionResult Index()
        {
            return View(db.Uplatas.ToList());
        }

        // GET: Uplata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uplata uplata = db.Uplatas.Find(id);
            if (uplata == null)
            {
                return HttpNotFound();
            }
            return View(uplata);
        }

        // GET: Uplata/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uplata/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UplataID,ObrzacPutneIsprave,AdministrativnaTaksa")] Uplata uplata)
        {
            if (ModelState.IsValid)
            {
                db.Uplatas.Add(uplata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uplata);
        }

        // GET: Uplata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uplata uplata = db.Uplatas.Find(id);
            if (uplata == null)
            {
                return HttpNotFound();
            }
            return View(uplata);
        }

        // POST: Uplata/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UplataID,ObrzacPutneIsprave,AdministrativnaTaksa")] Uplata uplata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uplata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uplata);
        }

        // GET: Uplata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uplata uplata = db.Uplatas.Find(id);
            if (uplata == null)
            {
                return HttpNotFound();
            }
            return View(uplata);
        }

        // POST: Uplata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uplata uplata = db.Uplatas.Find(id);
            db.Uplatas.Remove(uplata);
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
