using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Bordo.Models.ViewModel
{
    public class OrdenView
    {
        public Empleados Empleados { get; set; }

        public List<OrdenProductos> Productos { get; set; }

    }
}