namespace Sistema_Bordo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detalles_Pedido
    {
        [Key]
        public int Id_Detalle_Pedido { get; set; }

        public int Id_Pedido { get; set; }

        public int Id_productos { get; set; }

        public int Id_Estado_Pedido { get; set; }

        public decimal Cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal Precio { get; set; }

        public double? Descuento { get; set; }

        public DateTime Fecha_Asignacion { get; set; }

        public virtual Estado_Pedidos Estado_Pedidos { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
