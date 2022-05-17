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
    public class preguntasController : Controller
    {
        private Model1 db = new Model1();

        // GET: preguntas
        public ActionResult Index()
        {
            var preguntas = db.preguntas.Include(p => p.VideoEntrevista);
            return View(preguntas.ToList());
        }

        // GET: preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // GET: preguntas/Create
        public ActionResult Create()
        {
            ViewBag.VideoEntrevista_VEntrevistaID = new SelectList(db.VideoEntrevistas, "VEntrevistaID", "Name");
            return View();
        }

        // POST: preguntas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "preguntaID,VideoentrevistaID,orderPregID,description,VideoEntrevista_VEntrevistaID")] pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.preguntas.Add(pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VideoEntrevista_VEntrevistaID = new SelectList(db.VideoEntrevistas, "VEntrevistaID", "Name", pregunta.VideoEntrevista_VEntrevistaID);
            return View(pregunta);
        }

        // GET: preguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.VideoEntrevista_VEntrevistaID = new SelectList(db.VideoEntrevistas, "VEntrevistaID", "Name", pregunta.VideoEntrevista_VEntrevistaID);
            return View(pregunta);
        }

        // POST: preguntas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "preguntaID,VideoentrevistaID,orderPregID,description,VideoEntrevista_VEntrevistaID")] pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VideoEntrevista_VEntrevistaID = new SelectList(db.VideoEntrevistas, "VEntrevistaID", "Name", pregunta.VideoEntrevista_VEntrevistaID);
            return View(pregunta);
        }

        // GET: preguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pregunta pregunta = db.preguntas.Find(id);
            db.preguntas.Remove(pregunta);
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
