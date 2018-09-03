using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Bordo.Models
{
    public class OrdenProductos:Productos
    {
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "0:N2", ApplyFormatInEditMode = false)]
        public float Cantidad { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "0:C2", ApplyFormatInEditMode = false)]
        public decimal Valor { get { return Precio_Listado * (decimal)Cantidad; } }


    }
}