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
    public class EmpleadosController : Controller
    {
        private DB_Carga db = new DB_Carga();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Area).Include(e => e.Cargo);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Id_area = new SelectList(db.Area, "Id_area", "Descripcion");
            ViewBag.Id_cargo = new SelectList(db.Cargo, "Id_cargo", "Descripcion");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_empleado,Id_area,Id_cargo,Nombres,Apellidos,Direccion,DUI,NIT,AFP,Telefono_movil,telefono_fijo,Correo_Electronico")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_area = new SelectList(db.Area, "Id_area", "Descripcion", empleados.Id_area);
            ViewBag.Id_cargo = new SelectList(db.Cargo, "Id_cargo", "Descripcion", empleados.Id_cargo);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_area = new SelectList(db.Area, "Id_area", "Descripcion", empleados.Id_area);
            ViewBag.Id_cargo = new SelectList(db.Cargo, "Id_cargo", "Descripcion", empleados.Id_cargo);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_empleado,Id_area,Id_cargo,Nombres,Apellidos,Direccion,DUI,NIT,AFP,Telefono_movil,telefono_fijo,Correo_Electronico")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_area = new SelectList(db.Area, "Id_area", "Descripcion", empleados.Id_area);
            ViewBag.Id_cargo = new SelectList(db.Cargo, "Id_cargo", "Descripcion", empleados.Id_cargo);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
