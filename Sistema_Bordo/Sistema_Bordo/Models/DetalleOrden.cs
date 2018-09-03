using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_Bordo.Models
{
    public class DetalleOrden
    {

        [Key]
        public int DetalleOrdenID { get; set; }
        public int OrdenID { get; set; }
        public int Id_productos { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_Producto { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "0:C2", ApplyFormatInEditMode = false)]
        public decimal Precio_Listado { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "0:N2", ApplyFormatInEditMode = false)]
        public float Cantidad { get; set; }

        public virtual Orden Orden { get; set; }
        public virtual Productos Producto { get; set; }

    }
}