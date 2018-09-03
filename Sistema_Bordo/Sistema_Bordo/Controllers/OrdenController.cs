using Sistema_Bordo.Models;
using Sistema_Bordo.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Bordo.Controllers
{
    public class OrdenController : Controller
    {
        DB_Carga db = new DB_Carga();

        // GET: Orden
        public ActionResult NuevaOrden()
        {
            var Ordenview = new OrdenViews();
            Ordenview.Empleados = new Empleados();
            Ordenview.Productos = new List<OrdenProductos>();
            //esta es el viewbag para mandarle la lista empleados que tenemos en la base de datos pero 
            //hay que ordenarla
            var lista = db.Empleados.ToList();
            lista.Add(new Empleados { Id_empleado = 0, Nombres = "[ Seleccione un Empleado.....]" });
            lista = lista.OrderBy(c => c.Nombres);
            ViewBag.Empleado = new SelectList(lista, "Id_empleado", "Nombre");
            return View(Ordenview);
        }

        [HttpPost]
        public ActionResult NuevaOrden(OrdenViews ordenView)
        {
            var Ordenview = new OrdenViews();
            Ordenview.Empleados = new Empleados();
            Ordenview.Productos = new List<OrdenProductos>();
            //esta es el viewbag para mandarle la lista empleados que tenemos en la base de datos pero 
            //hay que ordenarla
            var lista = db.Empleado.ToList();
            lista.Add(new Empleados { Id_empleado = 0, Nombres = "[ Seleccione un Empleado.....]" });
            lista = lista.OrderBy(c => c.Nombre);
            ViewBag.Empleado = new SelectList(lista, "Id_empleado", "Nombre");

            return View(Ordenview);
        }

        public ActionResult CargarProducto(OrdenProductos ordenProductos)
        {
            return View(ordenProductos);
        }
        //colocar en esta parte el metodo conde serramos la base de datos

    }
}