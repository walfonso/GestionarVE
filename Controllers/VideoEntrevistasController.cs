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
    public class VideoEntrevistasController : Controller
    {
        private Model1 db = new Model1();

        // GET: VideoEntrevistas
        public ActionResult Index()
        {
            var videoEntrevistas = db.VideoEntrevistas.Include(v => v.Estado).Include(v => v.SolicitudPersonal);
            return View(videoEntrevistas.ToList());
        }

        // GET: VideoEntrevistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoEntrevista videoEntrevista = db.VideoEntrevistas.Find(id);
            if (videoEntrevista == null)
            {
                return HttpNotFound();
            }
            return View(videoEntrevista);
        }

        // GET: VideoEntrevistas/Create
        public ActionResult Create(int? idSolPer)
        {
            if (idSolPer == null)
            {
                ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto");
                ViewBag.enable = "_enabled = true";
            }
            else {
                ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto", idSolPer);
                ViewBag.enable = "@disabled = disabled";
            }

            ViewBag.estado_EstadoID = new SelectList(db.Estadoes, "EstadoID", "Descrption");
            ViewBag.idSol = idSolPer;
            
            return View();
        }

        // POST: VideoEntrevistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VEntrevistaID,Name,estado_EstadoID,SolicitudPersonal_SolPerID")] VideoEntrevista videoEntrevista)
        {
            if (ModelState.IsValid)
            {
                db.VideoEntrevistas.Add(videoEntrevista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estado_EstadoID = new SelectList(db.Estadoes, "EstadoID", "Descrption", videoEntrevista.estado_EstadoID);
            ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto", videoEntrevista.SolicitudPersonal_SolPerID);
            return View(videoEntrevista);
        }

        // GET: VideoEntrevistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoEntrevista videoEntrevista = db.VideoEntrevistas.Find(id);
            if (videoEntrevista == null)
            {
                return HttpNotFound();
            }
            ViewBag.estado_EstadoID = new SelectList(db.Estadoes, "EstadoID", "Descrption", videoEntrevista.estado_EstadoID);
            ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto", videoEntrevista.SolicitudPersonal_SolPerID);
            return View(videoEntrevista);
        }

        // POST: VideoEntrevistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VEntrevistaID,Name,estado_EstadoID,SolicitudPersonal_SolPerID")] VideoEntrevista videoEntrevista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoEntrevista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estado_EstadoID = new SelectList(db.Estadoes, "EstadoID", "Descrption", videoEntrevista.estado_EstadoID);
            ViewBag.SolicitudPersonal_SolPerID = new SelectList(db.SolicitudPersonals, "SolPerID", "Puesto", videoEntrevista.SolicitudPersonal_SolPerID);
            return View(videoEntrevista);
        }

        // GET: VideoEntrevistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoEntrevista videoEntrevista = db.VideoEntrevistas.Find(id);
            if (videoEntrevista == null)
            {
                return HttpNotFound();
            }
            return View(videoEntrevista);
        }

        // POST: VideoEntrevistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoEntrevista videoEntrevista = db.VideoEntrevistas.Find(id);
            db.VideoEntrevistas.Remove(videoEntrevista);
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
