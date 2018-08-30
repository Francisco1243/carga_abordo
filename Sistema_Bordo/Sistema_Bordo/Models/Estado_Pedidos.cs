namespace Sistema_Bordo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estado_Pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado_Pedidos()
        {
            Detalles_Pedido = new HashSet<Detalles_Pedido>();
        }

        [Key]
        public int Id_Estado_Pedido { get; set; }

        public int Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalles_Pedido> Detalles_Pedido { get; set; }
    }
}
