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
    public class MonedaController : Controller
    {
        private UnityOfWork unityofwork = UnityOfWork.Instance;
        // GET: Alojamiento
        public ActionResult Index()
        {
            return View(unityofwork.Monedas.GetAll());
        }

        // GET: Alojamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda Moneda = unityofwork.Monedas.Get(id);
            if (Moneda == null)
            {
                return HttpNotFound();
            }
            return View(Moneda);
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
        public ActionResult Create([Bind(Include = "idMoneda,descripcion")] Moneda Moneda)
        {
            if (ModelState.IsValid)
            {
                unityofwork.Monedas.Add(Moneda);
                unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Moneda);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda Moneda = unityofwork.Monedas.Get(id);
            if (Moneda == null)
            {
                return HttpNotFound();
            }
            return View(Moneda);
        }

        // POST: Actors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMoneda,descripcion")] Moneda Moneda)
        {
            if (ModelState.IsValid)
            {
                unityofwork.StateModified(Moneda);
                unityofwork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Moneda);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda Moneda = unityofwork.Monedas.Get(id);
            if (Moneda == null)
            {
                return HttpNotFound();
            }
            return View(Moneda);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moneda Moneda = unityofwork.Monedas.Get(id);
            unityofwork.Monedas.Remove(Moneda);
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