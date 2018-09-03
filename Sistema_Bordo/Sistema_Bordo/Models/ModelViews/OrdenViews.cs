using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Bordo.Models.ModelViews
{
    public class OrdenViews
    {

        public Empleados Empleados { get; set; }

        public List<OrdenProductos> Productos { get; set; }
    }
}