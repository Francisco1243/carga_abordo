namespace Sistema_Bordo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        public int Id_clientes { get; set; }

        [StringLength(50)]
        public string Empresa_Negocio { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(10)]
        public string DUI { get; set; }

        [StringLength(50)]
        public string Correo_Electronico { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono_Movil { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono_Fijo { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
