using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WormBook.Models;

public partial class MiContexto : DbContext
{
    public MiContexto()
    {
    }

    public MiContexto(DbContextOptions<MiContexto> options)
        : base(options)
    {
    }


    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Existencium> Existencia { get; set; }

    public virtual DbSet<Juegomesa> Juegomesas { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Pedidoespecial> Pedidoespecials { get; set; }

    public virtual DbSet<ProductPriv> ProductPrivs { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Productosenviado> Productosenviados { get; set; }

    public virtual DbSet<Productovendido> Productovendidos { get; set; }

  

    public virtual DbSet<Repodetalle> Repodetalles { get; set; }

    public virtual DbSet<Repopedido> Repopedidos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Tarjetaregalo> Tarjetaregalos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("USING_NLS_COMP");

 

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente);

            entity.ToTable("CLIENTE");

            entity.Property(e => e.Idcliente)
                .HasPrecision(10)
                .HasColumnName("IDCLIENTE");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.Guiaenvio);

            entity.ToTable("ENVIO");

            entity.Property(e => e.Guiaenvio)
                .HasPrecision(10)
                .HasColumnName("GUIAENVIO");
            entity.Property(e => e.Numcajas)
                .HasPrecision(10)
                .HasColumnName("NUMCAJAS");
            entity.Property(e => e.Sucursaldestino)
                .HasPrecision(10)
                .HasColumnName("SUCURSALDESTINO");
            entity.Property(e => e.Sucursalorigen)
                .HasPrecision(10)
                .HasColumnName("SUCURSALORIGEN");

            entity.HasOne(d => d.SucursaldestinoNavigation).WithMany(p => p.EnvioSucursaldestinoNavigations)
                .HasForeignKey(d => d.Sucursaldestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENVIO_SUCURSALDESTINO");

            entity.HasOne(d => d.SucursalorigenNavigation).WithMany(p => p.EnvioSucursalorigenNavigations)
                .HasForeignKey(d => d.Sucursalorigen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENVIO_SUCURSALORIGEN");
        });

        modelBuilder.Entity<Existencium>(entity =>
        {
            entity.HasKey(e => new { e.CodigoInterno, e.Codigosucursal });

            entity.ToTable("EXISTENCIA");

            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Codigosucursal)
                .HasPrecision(10)
                .HasColumnName("CODIGOSUCURSAL");
            entity.Property(e => e.Existencia)
                .HasPrecision(10)
                .HasColumnName("EXISTENCIA");

            entity.HasOne(d => d.CodigointernoNavigation).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.CodigoInterno)
                .HasConstraintName("FK_EXISTENCIA_PRODUCTO");

            entity.HasOne(d => d.CodigosucursalNavigation).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.Codigosucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EXISTENCIA_SUCURSAL");
        });

        modelBuilder.Entity<Juegomesa>(entity =>
        {
            entity.HasKey(e => e.Codigointerno);

            entity.ToTable("JUEGOMESA");

            entity.Property(e => e.Codigointerno)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARCA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.URL)
               .HasMaxLength(255)
               .IsUnicode(false)
               .HasColumnName("URL");
            entity.HasOne(d => d.CodigointernoNavigation).WithOne(p => p.Juegomesa)
                .HasForeignKey<Juegomesa>(d => d.Codigointerno)
                .HasConstraintName("FK_JUEGOMESA_PRODUCTO");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.CodigoInterno);

            entity.ToTable("LIBRO");

            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AUTOR");
            entity.Property(e => e.Editorial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDITORIAL");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITULO");

            entity.HasOne(d => d.CodigoInternoNavigation).WithOne(p => p.Libro)
                .HasForeignKey<Libro>(d => d.CodigoInterno)
                .HasConstraintName("FK_LIBRO_PRODUCTO");
        });

        modelBuilder.Entity<Pedidoespecial>(entity =>
        {
            entity.HasKey(e => e.Numpedido);

            entity.ToTable("PEDIDOESPECIAL");

            entity.Property(e => e.Numpedido)
                .HasPrecision(10)
                .HasColumnName("NUMPEDIDO");
            entity.Property(e => e.Cantidadpedida)
                .HasPrecision(10)
                .HasColumnName("CANTIDADPEDIDA");
            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Codigosucursal)
                .HasPrecision(10)
                .HasColumnName("CODIGOSUCURSAL");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fechapedido)
                .HasColumnType("DATE")
                .HasColumnName("FECHAPEDIDO");
            entity.Property(e => e.Idcliente)
                .HasPrecision(10)
                .HasColumnName("IDCLIENTE");

            entity.HasOne(d => d.CodigoInternoNavigation).WithMany(p => p.Pedidoespecials)
                .HasForeignKey(d => d.CodigoInterno)
                .HasConstraintName("FK_PEDIDOESPECIAL_PRODUCTO");

            entity.HasOne(d => d.CodigosucursalNavigation).WithMany(p => p.Pedidoespecials)
                .HasForeignKey(d => d.Codigosucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDOESPECIAL_SUCURSAL");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Pedidoespecials)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDOESPECIAL_CLIENTE");
        });

        modelBuilder.Entity<ProductPriv>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PRODUCT_PRIVS");

            entity.Property(e => e.Attribute)
                .HasMaxLength(240)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE");
            entity.Property(e => e.CharValue)
                .HasMaxLength(240)
                .IsUnicode(false)
                .HasColumnName("CHAR_VALUE");
            entity.Property(e => e.DateValue)
                .HasColumnType("DATE")
                .HasColumnName("DATE_VALUE");
            entity.Property(e => e.LongValue)
                .HasColumnType("LONG")
                .HasColumnName("LONG_VALUE");
            entity.Property(e => e.NumericValue)
                .HasColumnType("NUMBER(15,2)")
                .HasColumnName("NUMERIC_VALUE");
            entity.Property(e => e.Product)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PRODUCT");
            entity.Property(e => e.Scope)
                .HasMaxLength(240)
                .IsUnicode(false)
                .HasColumnName("SCOPE");
            entity.Property(e => e.Userid)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("USERID");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoInterno);

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Codigobarras)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CODIGOBARRAS");
            entity.Property(e => e.Precio)
                .HasPrecision(10)
                .HasColumnName("PRECIO");
        });

        modelBuilder.Entity<Productosenviado>(entity =>
        {
            entity.HasKey(e => new { e.CodigoInterno, e.Guiaenvio });

            entity.ToTable("PRODUCTOSENVIADOS");

            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Guiaenvio)
                .HasPrecision(10)
                .HasColumnName("GUIAENVIO");
            entity.Property(e => e.Cantidadenviada)
                .HasPrecision(10)
                .HasColumnName("CANTIDADENVIADA");
            entity.Property(e => e.Novedad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NOVEDAD");
            entity.Property(e => e.Numpedidoesp)
                .HasPrecision(10)
                .HasColumnName("NUMPEDIDOESP");

            entity.HasOne(d => d.CodigoInternoNavigation).WithMany(p => p.Productosenviados)
                .HasForeignKey(d => d.CodigoInterno)
                .HasConstraintName("FK_PRODUCTOSENVIADOS_PRODUCTO");

            entity.HasOne(d => d.GuiaenvioNavigation).WithMany(p => p.Productosenviados)
                .HasForeignKey(d => d.Guiaenvio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOSENVIADOS_ENVIO");

            entity.HasOne(d => d.NumpedidoespNavigation).WithMany(p => p.Productosenviados)
                .HasForeignKey(d => d.Numpedidoesp)
                .HasConstraintName("FK_PRODUCTOSENVIADOS_PEDIDOESPECIAL");
        });

        modelBuilder.Entity<Productovendido>(entity =>
        {
            entity.HasKey(e => new { e.CodigoInterno, e.Numventa });

            entity.ToTable("PRODUCTOVENDIDO");

            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Numventa)
                .HasPrecision(10)
                .HasColumnName("NUMVENTA");
            entity.Property(e => e.Cantidadvendida)
                .HasPrecision(10)
                .HasColumnName("CANTIDADVENDIDA");

            entity.HasOne(d => d.CodigoInternoNavigation).WithMany(p => p.Productovendidos)
                .HasForeignKey(d => d.CodigoInterno)
                .HasConstraintName("FK_PRODUCTOVENDIDO_PRODUCTO");

            entity.HasOne(d => d.NumventaNavigation).WithMany(p => p.Productovendidos)
                .HasForeignKey(d => d.Numventa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOVENDIDO_VENTA");
        });
        modelBuilder.Entity<Repodetalle>(entity =>
        {
            entity.HasKey(e => new { e.CodigoInterno, e.Numrepo });

            entity.ToTable("REPODETALLES");

            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Numrepo)
                .HasPrecision(10)
                .HasColumnName("NUMREPO");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .HasColumnName("CANTIDAD");

            entity.HasOne(d => d.CodigoInternoNavigation).WithMany(p => p.Repodetalles)
                .HasForeignKey(d => d.CodigoInterno)
                .HasConstraintName("FK_REPODETALLES_PRODUCTO");

            entity.HasOne(d => d.NumrepoNavigation).WithMany(p => p.Repodetalles)
                .HasForeignKey(d => d.Numrepo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REPODETALLES_REPOPEDIDO");
        });

        modelBuilder.Entity<Repopedido>(entity =>
        {
            entity.HasKey(e => e.Numrepo);

            entity.ToTable("REPOPEDIDO");

            entity.Property(e => e.Numrepo)
                .HasPrecision(10)
                .HasColumnName("NUMREPO");
            entity.Property(e => e.Codigosucursal)
                .HasPrecision(10)
                .HasColumnName("CODIGOSUCURSAL");
            entity.Property(e => e.Fechapedido)
                .HasColumnType("DATE")
                .HasColumnName("FECHAPEDIDO");

            entity.HasOne(d => d.CodigosucursalNavigation).WithMany(p => p.Repopedidos)
                .HasForeignKey(d => d.Codigosucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REPOPEDIDO_SUCURSAL");
        });
        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Codigosucursal);

            entity.ToTable("SUCURSAL");

            entity.Property(e => e.Codigosucursal)
                .HasPrecision(10)
                .HasColumnName("CODIGOSUCURSAL");
            entity.Property(e => e.Nombresucursal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRESUCURSAL");
            entity.Property(e => e.Telefonosucursal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONOSUCURSAL");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UBICACION");
        });

        modelBuilder.Entity<Tarjetaregalo>(entity =>
        {
            entity.HasKey(e => e.CodigoInterno);

            entity.ToTable("TARJETAREGALO");

            entity.Property(e => e.CodigoInterno)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("CODIGOINTERNO");
            entity.Property(e => e.Saldo)
                .HasPrecision(10)
                .HasColumnName("SALDO");

            entity.HasOne(d => d.CodigoInternoNavigation).WithOne(p => p.Tarjetaregalo)
                .HasForeignKey<Tarjetaregalo>(d => d.CodigoInterno)
                .HasConstraintName("FK_TARJETAREGALO_PRODUCTO");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Numventa);

            entity.ToTable("VENTA");

            entity.Property(e => e.Numventa)
                .HasPrecision(10)
                .HasColumnName("NUMVENTA");
            entity.Property(e => e.Codigosucursal)
                .HasPrecision(10)
                .HasColumnName("CODIGOSUCURSAL");
            entity.Property(e => e.Fechacompra)
                .HasColumnType("DATE")
                .HasColumnName("FECHACOMPRA");
            entity.Property(e => e.Total)
                .HasPrecision(10)
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.CodigosucursalNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Codigosucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENTA_SUCURSAL");
        });
        modelBuilder.HasSequence("CLIENTE_SEQ");
        modelBuilder.HasSequence("ENVIO_SEQ");
        modelBuilder.HasSequence("PEDIDOESPECIAL_SEQ");
        modelBuilder.HasSequence("PRODUCTO_SEQ");
        modelBuilder.HasSequence("REPOPEDIDO_SEQ");
        modelBuilder.HasSequence("SUCURSAL_SEQ");
        modelBuilder.HasSequence("VENTA_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
