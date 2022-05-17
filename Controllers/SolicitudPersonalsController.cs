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
    public class SolicitudPersonalsController : Controller
    {
        private Model1 db = new Model1();

        // GET: SolicitudPersonals
        public ActionResult Index()
        {
            var solicitudPersonals = db.SolicitudPersonals
                .Include(s => s.CIUO)
                .Include(p => p.Preseleccionadoes)
                .Include(e => e.VideoEntrevistas);
            return View(solicitudPersonals.ToList());
        }

        // GET: SolicitudPersonals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudPersonal solicitudPersonal = db.SolicitudPersonals.Find(id);
            if (solicitudPersonal == null)
            {
                return HttpNotFound();
            }
            return View(solicitudPersonal);
        }

        // GET: SolicitudPersonals/Create
        public ActionResult Create()
        {
            ViewBag.CIOUID = new SelectList(db.CIUOs, "CiouID", "Description");
       
            return View();
        }

        // POST: SolicitudPersonals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolPerID,EmpresaID,CIOUID,Puesto,CantPuesto")] SolicitudPersonal solicitudPersonal)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudPersonals.Add(solicitudPersonal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CIOUID = new SelectList(db.CIUOs, "CiouID", "Description", solicitudPersonal.CIOUID);
            return View(solicitudPersonal);
        }

        // GET: SolicitudPersonals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudPersonal solicitudPersonal = db.SolicitudPersonals.Find(id);
            if (solicitudPersonal == null)
            {
                return HttpNotFound();
            }
            ViewBag.CIOUID = new SelectList(db.CIUOs, "CiouID", "Description", solicitudPersonal.CIOUID);
            return View(solicitudPersonal);
        }

        // POST: SolicitudPersonals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SolPerID,EmpresaID,CIOUID,Puesto,CantPuesto")] SolicitudPersonal solicitudPersonal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudPersonal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CIOUID = new SelectList(db.CIUOs, "CiouID", "Description", solicitudPersonal.CIOUID);
            return View(solicitudPersonal);
        }

        // GET: SolicitudPersonals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudPersonal solicitudPersonal = db.SolicitudPersonals.Find(id);
            if (solicitudPersonal == null)
            {
                return HttpNotFound();
            }
            return View(solicitudPersonal);
        }

        // POST: SolicitudPersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudPersonal solicitudPersonal = db.SolicitudPersonals.Find(id);
            db.SolicitudPersonals.Remove(solicitudPersonal);
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
