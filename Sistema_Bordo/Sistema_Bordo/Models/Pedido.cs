namespace Sistema_Bordo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            Detalles_Pedido = new HashSet<Detalles_Pedido>();
        }

        [Key]
        public int Id_Pedido { get; set; }

        public int Id_empleado { get; set; }

        public int Id_clientes { get; set; }

        public int Id_Tipo_Pago { get; set; }

        public DateTime Fecha_Pedido { get; set; }

        public DateTime Fecha_Envio { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion_Envio { get; set; }

        public DateTime Fecha_Pago { get; set; }

        public virtual Clientes Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalles_Pedido> Detalles_Pedido { get; set; }

        public virtual Empleados Empleados { get; set; }

        public virtual Tipo_Pago Tipo_Pago { get; set; }
    }
}
