using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ErojasProgramacionNcapasContext : DbContext
{
    public ErojasProgramacionNcapasContext()
    {
    }

    public ErojasProgramacionNcapasContext(DbContextOptions<ErojasProgramacionNcapasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abc> Abcs { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Colonium> Colonia { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<ImagenUsuario> ImagenUsuarios { get; set; }

    public virtual DbSet<Libra> Libras { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Plantel> Plantels { get; set; }

    public virtual DbSet<PlantelCarrera> PlantelCarreras { get; set; }

    public virtual DbSet<Practica1> Practica1s { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Usuario2> Usuario2s { get; set; }
    public virtual DbSet<UsuarioGetAllDTO> UsuarioGetAllDTO { get; set; }

    /*
      */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=ERojasProgramacionNCapas; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<UsuarioGetAllDTO>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<Abc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Abc");

            entity.Property(e => e.IdAbc).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__Carreras__884A8F1FB50E837E");

            entity.Property(e => e.IdCarrera).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Colonium>(entity =>
        {
            entity.HasKey(e => e.IdColonia).HasName("PK__Colonia__A1580F66C090BFC0");

            entity.Property(e => e.IdColonia).ValueGeneratedNever();
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Colonia)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Colonia__IdMunic__3B75D760");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C76687163D2");

            entity.ToTable("Direccion");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("FK__Direccion__IdCol__3E52440B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Direccion_Usuario");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC151F6AABB");

            entity.ToTable("Estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ImagenUsuario>(entity =>
        {
            entity.HasKey(e => e.IdImagenUsuario);

            entity.ToTable("ImagenUsuario");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ImagenUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__ImagenUsu__IdUsu__29572725");
        });

        modelBuilder.Entity<Libra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Libra");

            entity.Property(e => e.Autor)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IdLibra).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materia__3214EC07B4920098");

            entity.Property(e => e.Costo).HasColumnType("decimal(15, 0)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978008D7FE3");

            entity.ToTable("Municipio");

            entity.Property(e => e.IdMunicipio).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Municipio__IdEst__38996AB5");
        });

        modelBuilder.Entity<Plantel>(entity =>
        {
            entity.HasKey(e => e.IdPlantel).HasName("PK__Plantels__485FDCFEF76FD151");

            entity.Property(e => e.IdPlantel).ValueGeneratedNever();
            entity.Property(e => e.NombreCorto)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlantelCarrera>(entity =>
        {
            entity.HasKey(e => e.IdPlantelCarrera).HasName("PK__Plantel___1E831A5E7155A14A");

            entity.ToTable("Plantel_Carrera");

            entity.Property(e => e.IdPlantelCarrera).ValueGeneratedNever();

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.PlantelCarreras)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Plantel_C__IdCar__2A4B4B5E");

            entity.HasOne(d => d.IdPlantelNavigation).WithMany(p => p.PlantelCarreras)
                .HasForeignKey(d => d.IdPlantel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Plantel_C__IdPla__2B3F6F97");
        });

        modelBuilder.Entity<Practica1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Practica1");

            entity.Property(e => e.IdPractica).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre2)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C23FE05B7");

            entity.ToTable("Rol");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__TABLE1__94F7C059109B9521");

            entity.ToTable("TABLE1");

            entity.Property(e => e.Iduser).HasColumnName("IDUSER");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534F2747BDB").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Usuario__C9F28456069735B0").IsUnique();

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Curp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdRol__2C3393D0");
        });

        modelBuilder.Entity<Usuario2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario2__3214EC0799CC042B");

            entity.ToTable("Usuario2");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
