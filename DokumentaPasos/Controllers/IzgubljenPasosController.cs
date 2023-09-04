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
    public class IzgubljenPasosController : Controller
    {
        private readonly LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: IzgubljenPasos
        public ActionResult Index()
        {
            return View(db.IzgubljenPasos.ToList());
        }

        // GET: IzgubljenPasos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzgubljenPaso izgubljenPaso = db.IzgubljenPasos.Find(id);
            if (izgubljenPaso == null)
            {
                return HttpNotFound();
            }
            return View(izgubljenPaso);
        }

        // GET: IzgubljenPasos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IzgubljenPasos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IzgubljenPasosID,PrijavaNestanka,NevazecaIsprava,VadiNoviPasos")] IzgubljenPaso izgubljenPaso)
        {
            if (ModelState.IsValid)
            {
                db.IzgubljenPasos.Add(izgubljenPaso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(izgubljenPaso);
        }

        // GET: IzgubljenPasos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzgubljenPaso izgubljenPaso = db.IzgubljenPasos.Find(id);
            if (izgubljenPaso == null)
            {
                return HttpNotFound();
            }
            return View(izgubljenPaso);
        }

        // POST: IzgubljenPasos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IzgubljenPasosID,PrijavaNestanka,NevazecaIsprava,VadiNoviPasos")] IzgubljenPaso izgubljenPaso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izgubljenPaso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(izgubljenPaso);
        }

        // GET: IzgubljenPasos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzgubljenPaso izgubljenPaso = db.IzgubljenPasos.Find(id);
            if (izgubljenPaso == null)
            {
                return HttpNotFound();
            }
            return View(izgubljenPaso);
        }

        // POST: IzgubljenPasos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IzgubljenPaso izgubljenPaso = db.IzgubljenPasos.Find(id);
            db.IzgubljenPasos.Remove(izgubljenPaso);
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
