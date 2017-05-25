using Glamar.Persistence.Repositories;
using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Glamar.mvc.Controllers
{
    public class AlojamientoController : Controller
    {
        private UnityOfWork _unityofwork = UnityOfWork.Instance;
        // GET: Alojamiento
        public ActionResult Index()
        {
            return View(_unityofwork.Alojamiento.GetAll());
        }

        // GET: Alojamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamiento Alojamiento = _unityofwork.Alojamiento.Get(id);
            if (Alojamiento == null)
            {
                return HttpNotFound();
            }
            return View(Alojamiento);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAlojamiento,idReserva,nomHospedaje,nroHab")] Alojamiento Alojamiento)
        {
            if (ModelState.IsValid)
            {
                _unityofwork.Alojamiento.Add(Alojamiento);
                _unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Alojamiento);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamiento Alojamiento = _unityofwork.Alojamiento.Get(id);
            if (Alojamiento == null)
            {
                return HttpNotFound();
            }
            return View(Alojamiento);
        }

        // POST: Actors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAlojamiento,idReserva,nomHospedaje,nroHab")] Alojamiento Alojamiento)
        {
            if (ModelState.IsValid)
            {
                _unityofwork.StateModified(Alojamiento);
                _unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Alojamiento);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamiento Alojamiento = _unityofwork.Alojamiento.Get(id);
            if (Alojamiento == null)
            {
                return HttpNotFound();
            }
            return View(Alojamiento);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alojamiento Alojamiento = _unityofwork.Alojamiento.Get(id);
            _unityofwork.Alojamiento.Remove(Alojamiento);
            _unityofwork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unityofwork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
