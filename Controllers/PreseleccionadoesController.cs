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
    public class PreseleccionadoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Preseleccionadoes
        public ActionResult Index()
        {
            var preseleccionadoes = db.Preseleccionadoes.Include(p => p.SolicitudPersonal);
            return View(preseleccionadoes.ToList());
        }

        // GET: Preseleccionadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preseleccionado preseleccionado = db.Preseleccionadoes.Find(id);
            if (preseleccionado == null)
            {
                return HttpNotFound();
            }
            return View(preseleccionado);
        }

        // GET: Preseleccionadoes/Create
        public ActionResult Create()
        {
            ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto");
            return View();
        }

        // POST: Preseleccionadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPre,codeKey,codeSolPer,fullname,email,SolicitudPersonal_SolPerID")] Preseleccionado preseleccionado)
        {
            if (ModelState.IsValid)
            {
                db.Preseleccionadoes.Add(preseleccionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto", preseleccionado.SolicitudPersonal_SolPerID);
            return View(preseleccionado);
        }

        // GET: Preseleccionadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preseleccionado preseleccionado = db.Preseleccionadoes.Find(id);
            if (preseleccionado == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto", preseleccionado.SolicitudPersonal_SolPerID);
            return View(preseleccionado);
        }

        // POST: Preseleccionadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPre,codeKey,codeSolPer,fullname,email,SolicitudPersonal_SolPerID")] Preseleccionado preseleccionado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preseleccionado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto", preseleccionado.SolicitudPersonal_SolPerID);
            return View(preseleccionado);
        }

        // GET: Preseleccionadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preseleccionado preseleccionado = db.Preseleccionadoes.Find(id);
            if (preseleccionado == null)
            {
                return HttpNotFound();
            }
            return View(preseleccionado);
        }

        // POST: Preseleccionadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Preseleccionado preseleccionado = db.Preseleccionadoes.Find(id);
            db.Preseleccionadoes.Remove(preseleccionado);
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
