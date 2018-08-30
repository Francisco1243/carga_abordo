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
    public class ProductosController : Controller
    {
        private DB_Carga db = new DB_Carga();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Categoria).Include(p => p.Proveedores);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Categoria = new SelectList(db.Categoria, "Id_Categoria", "Descripcion");
            ViewBag.Id_Proveedor = new SelectList(db.Proveedores, "Id_Proveedor", "Compañia");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_productos,Id_Proveedor,Id_Categoria,Codigo_Producto,Nombre_Producto,Descripcion,Costo_Estandar,Precio_Listado,Nivel_Objetivo,Cantidad_Unidad")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Categoria = new SelectList(db.Categoria, "Id_Categoria", "Descripcion", productos.Id_Categoria);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedores, "Id_Proveedor", "Compañia", productos.Id_Proveedor);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Categoria = new SelectList(db.Categoria, "Id_Categoria", "Descripcion", productos.Id_Categoria);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedores, "Id_Proveedor", "Compañia", productos.Id_Proveedor);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_productos,Id_Proveedor,Id_Categoria,Codigo_Producto,Nombre_Producto,Descripcion,Costo_Estandar,Precio_Listado,Nivel_Objetivo,Cantidad_Unidad")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Categoria = new SelectList(db.Categoria, "Id_Categoria", "Descripcion", productos.Id_Categoria);
            ViewBag.Id_Proveedor = new SelectList(db.Proveedores, "Id_Proveedor", "Compañia", productos.Id_Proveedor);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
