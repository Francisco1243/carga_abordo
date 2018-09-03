using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Bordo.Models
{
    public class Orden
    {
        
        [Key]
        public int OrdenID { get; set; }
        public DateTime FechaOrden { get; set; }

        public int Id_empleado { get; set; }
        public EstadoOrden EstadoOrden { get; set; }

        public virtual Empleados empleado { get; set; }
        public virtual ICollection<DetalleOrden> DetalleOrdenes { get; set; }

        

    }
}