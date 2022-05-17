using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionarVE;

namespace GestionarVE.Controllers
{
    public class CIUOsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CIUOs
        public ActionResult Index()
        {
            return View(db.CIUOs.ToList());
        }

        // GET: CIUOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUO cIUO = db.CIUOs.Find(id);
            if (cIUO == null)
            {
                return HttpNotFound();
            }
            return View(cIUO);
        }

        // GET: CIUOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CIUOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CiouID,Code,Description,Denomination")] CIUO cIUO)
        {
            if (ModelState.IsValid)
            {
                db.CIUOs.Add(cIUO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cIUO);
        }

        // GET: CIUOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUO cIUO = db.CIUOs.Find(id);
            if (cIUO == null)
            {
                return HttpNotFound();
            }
            return View(cIUO);
        }

        // POST: CIUOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CiouID,Code,Description,Denomination")] CIUO cIUO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cIUO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cIUO);
        }

        // GET: CIUOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUO cIUO = db.CIUOs.Find(id);
            if (cIUO == null)
            {
                return HttpNotFound();
            }
            return View(cIUO);
        }

        // POST: CIUOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CIUO cIUO = db.CIUOs.Find(id);
            db.CIUOs.Remove(cIUO);
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
