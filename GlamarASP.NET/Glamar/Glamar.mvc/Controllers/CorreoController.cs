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
    public class CorreoController : Controller
    {
        private UnityOfWork unityofwork = UnityOfWork.Instance;
        // GET: Correo
        public ActionResult Index()
        {
            return View(unityofwork.Correos.GetAll());
        }

        // GET: Correo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correo Correo = unityofwork.Correos.Get(id);
            if (Correo == null)
            {
                return HttpNotFound();
            }
            return View(Correo);
        }

        // GET: Correo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Correo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCorreo, idCliente, tipo")] Correo Correo)
        {
            if (ModelState.IsValid)
            {
                unityofwork.Correos.Add(Correo);
                unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Correo);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correo Correo = unityofwork.Correos.Get(id);
            if (Correo == null)
            {
                return HttpNotFound();
            }
            return View(Correo);
        }

        // POST: Actors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCorreo, idCliente, tipo")] Correo Correo)
        {
            if (ModelState.IsValid)
            {
                unityofwork.StateModified(Correo);
                unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Correo);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correo Correo = unityofwork.Correos.Get(id);
            if (Correo == null)
            {
                return HttpNotFound();
            }
            return View(Correo);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Correo Correo = unityofwork.Correos.Get(id);
            unityofwork.Correos.Remove(Correo);
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