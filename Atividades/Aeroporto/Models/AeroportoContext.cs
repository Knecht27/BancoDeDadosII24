using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aeroporto.Models;

public partial class AeroportoContext : DbContext
{
    public AeroportoContext()
    {
    }

    public AeroportoContext(DbContextOptions<AeroportoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<Aeroporto> Aeroportos { get; set; }

    public virtual DbSet<Cidade> Cidades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ModeloAeronave> ModeloAeronaves { get; set; }

    public virtual DbSet<Passagem> Passagems { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<Poltrona> Poltronas { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=AEROPORTO; User ID=; Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.IdAeronave).HasName("PK_dbo.Aeronave");

            entity.ToTable("Aeronave");

            entity.Property(e => e.NomeAeronave)
                .HasMaxLength(120)
                .IsUnicode(false);

            entity.HasOne(d => d.ModeloAeronaveNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.ModeloAeronave)
                .HasConstraintName("FK__Aeronave__Modelo__2D27B809");

            entity.HasOne(d => d.PilotoNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.Piloto)
                .HasConstraintName("FK__Aeronave__Piloto__2E1BDC42");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.IdAeroporto).HasName("PK_dbo.Aeroporto");

            entity.ToTable("Aeroporto");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.HasOne(d => d.CidadeNavigation).WithMany(p => p.Aeroportos)
                .HasForeignKey(d => d.Cidade)
                .HasConstraintName("FK__Aeroporto__Cidad__267ABA7A");
        });

        modelBuilder.Entity<Cidade>(entity =>
        {
            entity.HasKey(e => e.IdCidade).HasName("PK_dbo.Cidade");

            entity.ToTable("Cidade");

            entity.Property(e => e.Cidade1)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Cidade");
            entity.Property(e => e.Estado)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_dbo.Cliente");

            entity.ToTable("Cliente");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Passagem)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<ModeloAeronave>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("PK_dbo.ModeloAeronave");

            entity.ToTable("ModeloAeronave");

            entity.Property(e => e.NomeModelo)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Passagem>(entity =>
        {
            entity.HasKey(e => e.IdPassagem).HasName("PK_dbo.Passagem");

            entity.ToTable("Passagem");

            entity.HasOne(d => d.AeroportoDecolagemNavigation).WithMany(p => p.PassagemAeroportoDecolagemNavigations)
                .HasForeignKey(d => d.AeroportoDecolagem)
                .HasConstraintName("FK__Passagem__Aeropo__3C69FB99");

            entity.HasOne(d => d.AeroportoPousoNavigation).WithMany(p => p.PassagemAeroportoPousoNavigations)
                .HasForeignKey(d => d.AeroportoPouso)
                .HasConstraintName("FK__Passagem__Aeropo__3D5E1FD2");

            entity.HasOne(d => d.ClientePassagemNavigation).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.ClientePassagem)
                .HasConstraintName("FK__Passagem__Client__398D8EEE");

            entity.HasOne(d => d.PoltronaNavigation).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.Poltrona)
                .HasConstraintName("FK__Passagem__Poltro__3B75D760");

            entity.HasOne(d => d.VooNumNavigation).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.VooNum)
                .HasConstraintName("FK__Passagem__VooNum__3A81B327");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto).HasName("PK_dbo.Pilotos");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.NomePiloto)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Poltrona>(entity =>
        {
            entity.HasKey(e => e.IdPoltrona).HasName("PK_dbo.Poltrona");

            entity.ToTable("Poltrona");

            entity.Property(e => e.NumPoltrona)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.IdVoo).HasName("PK_dbo.IdVoo");

            entity.ToTable("Voo");

            entity.Property(e => e.PrevistoDecolagem).HasColumnType("datetime");
            entity.Property(e => e.PrevistoPouso).HasColumnType("datetime");
            entity.Property(e => e.TempoDecolagem).HasColumnType("datetime");
            entity.Property(e => e.TempoPouso).HasColumnType("datetime");

            entity.HasOne(d => d.AeronaveNavigation).WithMany(p => p.Voos)
                .HasForeignKey(d => d.Aeronave)
                .HasConstraintName("FK__Voo__Aeronave__36B12243");

            entity.HasOne(d => d.DestinoNavigation).WithMany(p => p.VooDestinoNavigations)
                .HasForeignKey(d => d.Destino)
                .HasConstraintName("FK__Voo__Destino__35BCFE0A");

            entity.HasOne(d => d.PartidaNavigation).WithMany(p => p.VooPartidaNavigations)
                .HasForeignKey(d => d.Partida)
                .HasConstraintName("FK__Voo__Partida__34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
