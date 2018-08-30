namespace Sistema_Bordo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_Carga : DbContext
    {
        public DB_Carga()
            : base("name=DB_Carga")
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Detalles_Pedido> Detalles_Pedido { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Estado_Pedidos> Estado_Pedidos { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tipo_Pago> Tipo_Pago { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cargo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Cargo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Empresa_Negocio)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.DUI)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Correo_Electronico)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Telefono_Movil)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Telefono_Fijo)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detalles_Pedido>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.DUI)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.NIT)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Telefono_movil)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.telefono_fijo)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Correo_Electronico)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Empleados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado_Pedidos>()
                .Property(e => e.Nombre_Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Estado_Pedidos>()
                .HasMany(e => e.Detalles_Pedido)
                .WithRequired(e => e.Estado_Pedidos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.Direccion_Envio)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Detalles_Pedido)
                .WithRequired(e => e.Pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Codigo_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Costo_Estandar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Precio_Listado)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Cantidad_Unidad)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.Detalles_Pedido)
                .WithRequired(e => e.Productos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Compañia)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Apellidos)
                .IsFixedLength();

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Correo_Electronico)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.DUI)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Telefono_Fijo)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.Telefono_Movil)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Proveedores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Pago>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Pago>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Tipo_Pago)
                .WillCascadeOnDelete(false);
        }
    }
}
