using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Bordo.Models;

namespace Sistema_Bordo.Controllers
{
    public class EstadoPedidosController : Controller
    {
        private DB_Carga db = new DB_Carga();

        // GET: EstadoPedidos
        public ActionResult Index()
        {
            return View(db.Estado_Pedidos.ToList());
        }

        // GET: EstadoPedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Pedidos estado_Pedidos = db.Estado_Pedidos.Find(id);
            if (estado_Pedidos == null)
            {
                return HttpNotFound();
            }
            return View(estado_Pedidos);
        }

        // GET: EstadoPedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoPedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estado_Pedido,Codigo,Nombre_Estado")] Estado_Pedidos estado_Pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Pedidos.Add(estado_Pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Pedidos);
        }

        // GET: EstadoPedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Pedidos estado_Pedidos = db.Estado_Pedidos.Find(id);
            if (estado_Pedidos == null)
            {
                return HttpNotFound();
            }
            return View(estado_Pedidos);
        }

        // POST: EstadoPedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estado_Pedido,Codigo,Nombre_Estado")] Estado_Pedidos estado_Pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Pedidos);
        }

        // GET: EstadoPedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Pedidos estado_Pedidos = db.Estado_Pedidos.Find(id);
            if (estado_Pedidos == null)
            {
                return HttpNotFound();
            }
            return View(estado_Pedidos);
        }

        // POST: EstadoPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Pedidos estado_Pedidos = db.Estado_Pedidos.Find(id);
            db.Estado_Pedidos.Remove(estado_Pedidos);
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
