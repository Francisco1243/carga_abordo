namespace Sistema_Bordo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedores()
        {
            Productos = new HashSet<Productos>();
        }

        [Key]
        public int Id_Proveedor { get; set; }

        [Required]
        [StringLength(50)]
        public string Compañia { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(10)]
        public string Apellidos { get; set; }

        [StringLength(50)]
        public string Correo_Electronico { get; set; }

        [Required]
        [StringLength(10)]
        public string DUI { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Telefono_Fijo { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono_Movil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
