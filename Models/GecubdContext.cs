using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gecu_API.Models;

public partial class GecubdContext : DbContext
{
    public GecubdContext()
    {
    }

    public GecubdContext(DbContextOptions<GecubdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<EstadoSolicitud> EstadoSolicituds { get; set; }

    public virtual DbSet<EstadosDireccione> EstadosDirecciones { get; set; }

    public virtual DbSet<PropsAplicacione> PropsAplicaciones { get; set; }

    public virtual DbSet<PropsServicio> PropsServicios { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<SolicitudmMaplicacion> SolicitudmMaplicacions { get; set; }

    public virtual DbSet<SolicitudmMservicio> SolicitudmMservicios { get; set; }

    public virtual DbSet<SolicitudmMtipo> SolicitudmMtipos { get; set; }

    public virtual DbSet<TipoAplicacion> TipoAplicacions { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<TipoSolicitud> TipoSolicituds { get; set; }

    public virtual DbSet<Traza> Trazas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PRIMARY");

            entity.ToTable("cargo");

            entity.Property(e => e.IdCargo)
                .HasColumnType("int(11)")
                .HasColumnName("id_cargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PRIMARY");

            entity.ToTable("contrato");

            entity.Property(e => e.IdContrato)
                .HasColumnType("int(11)")
                .HasColumnName("id_contrato");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PRIMARY");

            entity.ToTable("direccion");

            entity.HasIndex(e => e.IdEstado, "FK__estados_direcciones");

            entity.Property(e => e.IdDireccion)
                .HasColumnType("int(11)")
                .HasColumnName("id_direccion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasColumnName("id_estado");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__estados_direcciones");
        });

        modelBuilder.Entity<EstadoSolicitud>(entity =>
        {
            entity.HasKey(e => e.IdEstadoSol).HasName("PRIMARY");

            entity.ToTable("estado_solicitud");

            entity.Property(e => e.IdEstadoSol)
                .HasColumnType("int(11)")
                .HasColumnName("id_estadoSol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<EstadosDireccione>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("estados_direcciones");

            entity.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasColumnName("id_estado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<PropsAplicacione>(entity =>
        {
            entity.HasKey(e => e.IdPropAplicacion).HasName("PRIMARY");

            entity.ToTable("props_aplicaciones");

            entity.HasIndex(e => e.IdTipoAplicacion, "FK_props_aplicaciones_tipo_aplicacion");

            entity.Property(e => e.IdPropAplicacion)
                .HasColumnType("int(11)")
                .HasColumnName("id_propAplicacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdTipoAplicacion)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipoAplicacion");

            entity.HasOne(d => d.IdTipoAplicacionNavigation).WithMany(p => p.PropsAplicaciones)
                .HasForeignKey(d => d.IdTipoAplicacion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_props_aplicaciones_tipo_aplicacion");
        });

        modelBuilder.Entity<PropsServicio>(entity =>
        {
            entity.HasKey(e => e.IdPropServicio).HasName("PRIMARY");

            entity.ToTable("props_servicios");

            entity.HasIndex(e => e.IdTipoServicio, "FK_props_servicios_tipo_servicio");

            entity.Property(e => e.IdPropServicio)
                .HasColumnType("int(11)")
                .HasColumnName("id_propServicio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdTipoServicio)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipoServicio");

            entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.PropsServicios)
                .HasForeignKey(d => d.IdTipoServicio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_props_servicios_tipo_servicio");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PRIMARY");

            entity.ToTable("solicitud");

            entity.HasIndex(e => e.Cargo, "FK_solicitud_cargo");

            entity.HasIndex(e => e.Direccion, "FK_solicitud_direccion");

            entity.HasIndex(e => e.EstadoSolicitud, "FK_solicitud_estado_solicitud");

            entity.HasIndex(e => e.TipoSolicitud, "FK_solicitud_tipo_solicitud");

            entity.HasIndex(e => e.UsuarioCreador, "FK_solicitud_usuario");

            entity.Property(e => e.IdSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("id_solicitud");
            entity.Property(e => e.Cargo)
                .HasColumnType("int(11)")
                .HasColumnName("cargo");
            entity.Property(e => e.CarnetIdentidad)
                .HasColumnType("int(11)")
                .HasColumnName("carnet_identidad");
            entity.Property(e => e.Direccion)
                .HasColumnType("int(11)")
                .HasColumnName("direccion");
            entity.Property(e => e.EstadoSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("estado_solicitud");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("curdate()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("tipo_solicitud");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");
            entity.Property(e => e.UsuarioCreador)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_creador");

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.Cargo)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_solicitud_cargo");

            entity.HasOne(d => d.DireccionNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.Direccion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_solicitud_direccion");

            entity.HasOne(d => d.EstadoSolicitudNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.EstadoSolicitud)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_solicitud_estado_solicitud");

            entity.HasOne(d => d.TipoSolicitudNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.TipoSolicitud)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_solicitud_tipo_solicitud");

            entity.HasOne(d => d.UsuarioCreadorNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.UsuarioCreador)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_solicitud_usuario");
        });

        modelBuilder.Entity<SolicitudmMaplicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solicitudm_maplicacion");

            entity.HasIndex(e => e.IdSolicitud, "FK__solicitud");

            entity.HasIndex(e => e.IdAplicacion, "FK_solicitudm_maplicacion_tipo_aplicacion");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdAplicacion)
                .HasColumnType("int(11)")
                .HasColumnName("id_aplicacion");
            entity.Property(e => e.IdSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("id_solicitud");

            entity.HasOne(d => d.IdAplicacionNavigation).WithMany(p => p.SolicitudmMaplicacions)
                .HasForeignKey(d => d.IdAplicacion)
                .HasConstraintName("FK_solicitudm_maplicacion_tipo_aplicacion");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.SolicitudmMaplicacions)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK__solicitud");
        });

        modelBuilder.Entity<SolicitudmMservicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solicitudm_mservicio");

            entity.HasIndex(e => e.IdSolicitud, "FK_solicitudm_mservicio_solicitud");

            entity.HasIndex(e => e.IdServicio, "FK_solicitudm_mservicio_tipo_servicio");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdServicio)
                .HasColumnType("int(11)")
                .HasColumnName("id_servicio");
            entity.Property(e => e.IdSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("id_solicitud");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.SolicitudmMservicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_solicitudm_mservicio_tipo_servicio");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.SolicitudmMservicios)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK_solicitudm_mservicio_solicitud");
        });

        modelBuilder.Entity<SolicitudmMtipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solicitudm_mtipo");

            entity.HasIndex(e => e.IdSolicitud, "FK_solicitudm_mtipo_solicitud");

            entity.HasIndex(e => e.IdTipoSolicitud, "FK_solicitudm_mtipo_tipo_solicitud");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("id_solicitud");
            entity.Property(e => e.IdTipoSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipo_solicitud");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.SolicitudmMtipos)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK_solicitudm_mtipo_solicitud");

            entity.HasOne(d => d.IdTipoSolicitudNavigation).WithMany(p => p.SolicitudmMtipos)
                .HasForeignKey(d => d.IdTipoSolicitud)
                .HasConstraintName("FK_solicitudm_mtipo_tipo_solicitud");
        });

        modelBuilder.Entity<TipoAplicacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoAplicacion).HasName("PRIMARY");

            entity.ToTable("tipo_aplicacion");

            entity.Property(e => e.IdTipoAplicacion)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipoAplicacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.IdTipoServicio).HasName("PRIMARY");

            entity.ToTable("tipo_servicio");

            entity.Property(e => e.IdTipoServicio)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipoServicio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TipoSolicitud>(entity =>
        {
            entity.HasKey(e => e.IdTipoSolicitud).HasName("PRIMARY");

            entity.ToTable("tipo_solicitud");

            entity.Property(e => e.IdTipoSolicitud)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipoSolicitud");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.RequiereConfirmacion)
                .HasColumnType("tinyint(4)")
                .HasColumnName("requiereConfirmacion");
        });

        modelBuilder.Entity<Traza>(entity =>
        {
            entity.HasKey(e => e.IdTraza).HasName("PRIMARY");

            entity.ToTable("traza");

            entity.HasIndex(e => e.UsuarioCreador, "FK_traza_usuario");

            entity.Property(e => e.IdTraza)
                .HasColumnType("int(11)")
                .HasColumnName("id_traza");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("curdate()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.UsuarioCreador)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_creador");

            entity.HasOne(d => d.UsuarioCreadorNavigation).WithMany(p => p.Trazas)
                .HasForeignKey(d => d.UsuarioCreador)
                .HasConstraintName("FK_traza_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.IdCargo, "FK_usuario_cargo");

            entity.HasIndex(e => e.IdContrato, "FK_usuario_contrato");

            entity.HasIndex(e => e.IdRol, "FK_usuario_roles");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("id_usuario");
            entity.Property(e => e.CarnetIdentidad)
                .HasColumnType("bigint(20)")
                .HasColumnName("carnet_identidad");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("estado");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("datetime")
                .HasColumnName("fechaContrato");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("curdate()")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdCargo)
                .HasColumnType("int(11)")
                .HasColumnName("id_cargo");
            entity.Property(e => e.IdContrato)
                .HasColumnType("int(11)")
                .HasColumnName("id_contrato");
            entity.Property(e => e.IdDireccion)
                .HasColumnType("int(11)")
                .HasColumnName("id_direccion");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(20)
                .HasColumnName("usuario");
            entity.Property(e => e.UsuarioCorreo)
                .HasMaxLength(20)
                .HasColumnName("usuarioCorreo");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_usuario_cargo");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdContrato)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_usuario_contrato");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_usuario_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
