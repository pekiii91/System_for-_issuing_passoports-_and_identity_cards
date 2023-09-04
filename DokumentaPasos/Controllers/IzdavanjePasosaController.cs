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
    public class IzdavanjePasosaController : Controller
    {
        private readonly LicnaDokumentaPasosEntities db = new LicnaDokumentaPasosEntities();

        // GET: IzdavanjePasosa
        public ActionResult Index()
        {
            return View(db.IzdavanjePasosas.ToList());
        }

        // GET: IzdavanjePasosa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzdavanjePasosa izdavanjePasosa = db.IzdavanjePasosas.Find(id);
            if (izdavanjePasosa == null)
            {
                return HttpNotFound();
            }
            return View(izdavanjePasosa);
        }

        // GET: IzdavanjePasosa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IzdavanjePasosa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IzdavanjePasosaID,LicnaKarta,IzvodMaticneKnjigeRodjenih,UverenjeODrzavljanstvu,UplataZaPasos")] IzdavanjePasosa izdavanjePasosa)
        {
            if (ModelState.IsValid)
            {
                db.IzdavanjePasosas.Add(izdavanjePasosa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(izdavanjePasosa);
        }

        // GET: IzdavanjePasosa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzdavanjePasosa izdavanjePasosa = db.IzdavanjePasosas.Find(id);
            if (izdavanjePasosa == null)
            {
                return HttpNotFound();
            }
            return View(izdavanjePasosa);
        }

        // POST: IzdavanjePasosa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IzdavanjePasosaID,LicnaKarta,IzvodMaticneKnjigeRodjenih,UverenjeODrzavljanstvu,UplataZaPasos")] IzdavanjePasosa izdavanjePasosa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izdavanjePasosa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(izdavanjePasosa);
        }

        // GET: IzdavanjePasosa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzdavanjePasosa izdavanjePasosa = db.IzdavanjePasosas.Find(id);
            if (izdavanjePasosa == null)
            {
                return HttpNotFound();
            }
            return View(izdavanjePasosa);
        }

        // POST: IzdavanjePasosa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IzdavanjePasosa izdavanjePasosa = db.IzdavanjePasosas.Find(id);
            db.IzdavanjePasosas.Remove(izdavanjePasosa);
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
