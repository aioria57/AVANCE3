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
    public class ClienteController : Controller
    {
        private UnityOfWork _unityofwork = UnityOfWork.Instance;
        // GET: Cliente
        public ActionResult Index()
        {
            return View(_unityofwork.Clientes.GetAll());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente Cliente = _unityofwork.Clientes.Get(id);
            if (Cliente == null)
            {
                return HttpNotFound();
            }
            return View(Cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST:Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,nombres,primApe,segApe,puntosDisponibles")] Cliente Cliente)
        {
            if (ModelState.IsValid)
            {
                _unityofwork.Clientes.Add(Cliente);
                _unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Cliente);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente Cliente = _unityofwork.Clientes.Get(id);
            if (Cliente == null)
            {
                return HttpNotFound();
            }
            return View(Cliente);
        }

        // POST: Actors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,nombres,primApe,segApe,puntosDisponibles")] Cliente Cliente)
        {
            if (ModelState.IsValid)
            {
                _unityofwork.StateModified(Cliente);
                _unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Cliente);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente Cliente = _unityofwork.Clientes.Get(id);
            if (Cliente == null)
            {
                return HttpNotFound();
            }
            return View(Cliente);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente Cliente = _unityofwork.Clientes.Get(id);
            _unityofwork.Clientes.Remove(Cliente);
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