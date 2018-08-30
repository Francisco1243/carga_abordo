namespace Sistema_Bordo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            Detalles_Pedido = new HashSet<Detalles_Pedido>();
        }

        [Key]
        public int Id_productos { get; set; }

        public int Id_Proveedor { get; set; }

        public int Id_Categoria { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo_Producto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_Producto { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal Costo_Estandar { get; set; }

        [Column(TypeName = "money")]
        public decimal Precio_Listado { get; set; }

        public int Nivel_Objetivo { get; set; }

        [Required]
        [StringLength(50)]
        public string Cantidad_Unidad { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalles_Pedido> Detalles_Pedido { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }
}
