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
    public class DetallesPedidoController : Controller
    {
        private DB_Carga db = new DB_Carga();

        // GET: DetallesPedido
        public ActionResult Index()
        {
            var detalles_Pedido = db.Detalles_Pedido.Include(d => d.Estado_Pedidos).Include(d => d.Pedido).Include(d => d.Productos);
            return View(detalles_Pedido.ToList());
        }

        // GET: DetallesPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles_Pedido detalles_Pedido = db.Detalles_Pedido.Find(id);
            if (detalles_Pedido == null)
            {
                return HttpNotFound();
            }
            return View(detalles_Pedido);
        }

        // GET: DetallesPedido/Create
        public ActionResult Create()
        {
            ViewBag.Id_Estado_Pedido = new SelectList(db.Estado_Pedidos, "Id_Estado_Pedido", "Nombre_Estado");
            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id_Pedido", "Direccion_Envio");
            ViewBag.Id_productos = new SelectList(db.Productos, "Id_productos", "Codigo_Producto");
            return View();
        }

        // POST: DetallesPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Detalle_Pedido,Id_Pedido,Id_productos,Id_Estado_Pedido,Cantidad,Precio,Descuento,Fecha_Asignacion")] Detalles_Pedido detalles_Pedido)
        {
            if (ModelState.IsValid)
            {
                db.Detalles_Pedido.Add(detalles_Pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Estado_Pedido = new SelectList(db.Estado_Pedidos, "Id_Estado_Pedido", "Nombre_Estado", detalles_Pedido.Id_Estado_Pedido);
            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id_Pedido", "Direccion_Envio", detalles_Pedido.Id_Pedido);
            ViewBag.Id_productos = new SelectList(db.Productos, "Id_productos", "Codigo_Producto", detalles_Pedido.Id_productos);
            return View(detalles_Pedido);
        }

        // GET: DetallesPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles_Pedido detalles_Pedido = db.Detalles_Pedido.Find(id);
            if (detalles_Pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Estado_Pedido = new SelectList(db.Estado_Pedidos, "Id_Estado_Pedido", "Nombre_Estado", detalles_Pedido.Id_Estado_Pedido);
            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id_Pedido", "Direccion_Envio", detalles_Pedido.Id_Pedido);
            ViewBag.Id_productos = new SelectList(db.Productos, "Id_productos", "Codigo_Producto", detalles_Pedido.Id_productos);
            return View(detalles_Pedido);
        }

        // POST: DetallesPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Detalle_Pedido,Id_Pedido,Id_productos,Id_Estado_Pedido,Cantidad,Precio,Descuento,Fecha_Asignacion")] Detalles_Pedido detalles_Pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalles_Pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Estado_Pedido = new SelectList(db.Estado_Pedidos, "Id_Estado_Pedido", "Nombre_Estado", detalles_Pedido.Id_Estado_Pedido);
            ViewBag.Id_Pedido = new SelectList(db.Pedido, "Id_Pedido", "Direccion_Envio", detalles_Pedido.Id_Pedido);
            ViewBag.Id_productos = new SelectList(db.Productos, "Id_productos", "Codigo_Producto", detalles_Pedido.Id_productos);
            return View(detalles_Pedido);
        }

        // GET: DetallesPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles_Pedido detalles_Pedido = db.Detalles_Pedido.Find(id);
            if (detalles_Pedido == null)
            {
                return HttpNotFound();
            }
            return View(detalles_Pedido);
        }

        // POST: DetallesPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalles_Pedido detalles_Pedido = db.Detalles_Pedido.Find(id);
            db.Detalles_Pedido.Remove(detalles_Pedido);
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
