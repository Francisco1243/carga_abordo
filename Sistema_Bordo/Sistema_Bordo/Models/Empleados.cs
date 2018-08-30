namespace Sistema_Bordo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        public int Id_empleado { get; set; }

        public int Id_area { get; set; }

        public int Id_cargo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string DUI { get; set; }

        [Required]
        [StringLength(16)]
        public string NIT { get; set; }

        public int AFP { get; set; }

        [Required]
        [StringLength(9)]
        [Display(Name = "Telefono movil")]
        public string Telefono_movil { get; set; }

        [StringLength(9)]
        [Display(Name = "Telefono Fijo")]
        public string telefono_fijo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Correo Electronico")]
        public string Correo_Electronico { get; set; }

        public virtual Area Area { get; set; }

        public virtual Cargo Cargo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
