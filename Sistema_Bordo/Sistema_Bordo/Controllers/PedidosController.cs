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
    public class PedidosController : Controller
    {
        private DB_Carga db = new DB_Carga();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Clientes).Include(p => p.Empleados).Include(p => p.Tipo_Pago);
            return View(pedido.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.Id_clientes = new SelectList(db.Clientes, "Id_clientes", "Empresa_Negocio");
            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres");
            ViewBag.Id_Tipo_Pago = new SelectList(db.Tipo_Pago, "Id_Tipo_Pago", "Descripcion");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Pedido,Id_empleado,Id_clientes,Id_Tipo_Pago,Fecha_Pedido,Fecha_Envio,Direccion_Envio,Fecha_Pago")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_clientes = new SelectList(db.Clientes, "Id_clientes", "Empresa_Negocio", pedido.Id_clientes);
            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres", pedido.Id_empleado);
            ViewBag.Id_Tipo_Pago = new SelectList(db.Tipo_Pago, "Id_Tipo_Pago", "Descripcion", pedido.Id_Tipo_Pago);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_clientes = new SelectList(db.Clientes, "Id_clientes", "Empresa_Negocio", pedido.Id_clientes);
            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres", pedido.Id_empleado);
            ViewBag.Id_Tipo_Pago = new SelectList(db.Tipo_Pago, "Id_Tipo_Pago", "Descripcion", pedido.Id_Tipo_Pago);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pedido,Id_empleado,Id_clientes,Id_Tipo_Pago,Fecha_Pedido,Fecha_Envio,Direccion_Envio,Fecha_Pago")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_clientes = new SelectList(db.Clientes, "Id_clientes", "Empresa_Negocio", pedido.Id_clientes);
            ViewBag.Id_empleado = new SelectList(db.Empleados, "Id_empleado", "Nombres", pedido.Id_empleado);
            ViewBag.Id_Tipo_Pago = new SelectList(db.Tipo_Pago, "Id_Tipo_Pago", "Descripcion", pedido.Id_Tipo_Pago);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
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
