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
    public class TelefonoController : Controller
    {
        private UnityOfWork unityofwork = UnityOfWork.Instance;
        // GET: Alojamiento
        public ActionResult Index()
        {
            return View(unityofwork.Telefonos.GetAll());
        }

        // GET: Alojamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono Telefono = unityofwork.Telefonos.Get(id);
            if (Telefono == null)
            {
                return HttpNotFound();
            }
            return View(Telefono);
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
        public ActionResult Create([Bind(Include = "idTelefono,idCliente,numero,tipo")] Telefono Telefono)
        {
            if (ModelState.IsValid)
            {
                unityofwork.Telefonos.Add(Telefono);
                unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Telefono);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono Telefono = unityofwork.Telefonos.Get(id);
            if (Telefono == null)
            {
                return HttpNotFound();
            }
            return View(Telefono);
        }

        // POST: Actors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTelefono,idCliente,numero,tipo")] Telefono Telefono)
        {
            if (ModelState.IsValid)
            {
                unityofwork.StateModified(Telefono);
                unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Telefono);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono Telefono = unityofwork.Telefonos.Get(id);
            if (Telefono == null)
            {
                return HttpNotFound();
            }
            return View(Telefono);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono Telefono = unityofwork.Telefonos.Get(id);
            unityofwork.Telefonos.Remove(Telefono);
            unityofwork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unityofwork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}