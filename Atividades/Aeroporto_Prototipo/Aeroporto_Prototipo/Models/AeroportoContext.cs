using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aeroporto_Prototipo.Models;

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
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=Aeroporto; User ID=; Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.IdAeronave).HasName("PK__Aeronave__2042F68A8FBC2926");

            entity.ToTable("Aeronave");

            entity.Property(e => e.NomeAeronave)
                .HasMaxLength(120)
                .IsUnicode(false);

            entity.HasOne(d => d.ModeloAeronaveNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.ModeloAeronave)
                .HasConstraintName("FK__Aeronave__Modelo__3F466844");

            entity.HasOne(d => d.PilotoNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.Piloto)
                .HasConstraintName("FK__Aeronave__Piloto__403A8C7D");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.IdAeroporto).HasName("PK__Aeroport__FAAA37D4C347BA8C");

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
                .HasConstraintName("FK__Aeroporto__Cidad__38996AB5");
        });

        modelBuilder.Entity<Cidade>(entity =>
        {
            entity.HasKey(e => e.IdCidade).HasName("PK__Cidade__160879A3905C0C1C");

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
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D59466424D7DC26B");

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
            entity.HasKey(e => e.IdModelo).HasName("PK__ModeloAe__CC30D30CD1BB77B2");

            entity.ToTable("ModeloAeronave");

            entity.Property(e => e.NomeModelo)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Passagem>(entity =>
        {
            entity.HasKey(e => e.IdPassagem).HasName("PK__Passagem__9509808BA25EC6FD");

            entity.ToTable("Passagem");

            entity.HasOne(d => d.AeroportoDecolagemNavigation).WithMany(p => p.PassagemAeroportoDecolagemNavigations)
                .HasForeignKey(d => d.AeroportoDecolagem)
                .HasConstraintName("FK__Passagem__Aeropo__4E88ABD4");

            entity.HasOne(d => d.AeroportoPousoNavigation).WithMany(p => p.PassagemAeroportoPousoNavigations)
                .HasForeignKey(d => d.AeroportoPouso)
                .HasConstraintName("FK__Passagem__Aeropo__4F7CD00D");

            entity.HasOne(d => d.ClientePassagemNavigation).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.ClientePassagem)
                .HasConstraintName("FK__Passagem__Client__4BAC3F29");

            entity.HasOne(d => d.PoltronaNavigation).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.Poltrona)
                .HasConstraintName("FK__Passagem__Poltro__4D94879B");

            entity.HasOne(d => d.VooNumNavigation).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.VooNum)
                .HasConstraintName("FK__Passagem__VooNum__4CA06362");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto).HasName("PK__Pilotos__DB35379FBB7853E8");

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
            entity.HasKey(e => e.IdPoltrona).HasName("PK__Poltrona__77555A833981F463");

            entity.ToTable("Poltrona");

            entity.Property(e => e.NumPoltrona)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.IdVoo).HasName("PK__Voo__2B4169CCFEB132AB");

            entity.ToTable("Voo");

            entity.Property(e => e.PrevistoDecolagem).HasColumnType("datetime");
            entity.Property(e => e.PrevistoPouso).HasColumnType("datetime");
            entity.Property(e => e.TempoDecolagem).HasColumnType("datetime");
            entity.Property(e => e.TempoPouso).HasColumnType("datetime");

            entity.HasOne(d => d.AeronaveNavigation).WithMany(p => p.Voos)
                .HasForeignKey(d => d.Aeronave)
                .HasConstraintName("FK__Voo__Aeronave__48CFD27E");

            entity.HasOne(d => d.DestinoNavigation).WithMany(p => p.VooDestinoNavigations)
                .HasForeignKey(d => d.Destino)
                .HasConstraintName("FK__Voo__Destino__47DBAE45");

            entity.HasOne(d => d.PartidaNavigation).WithMany(p => p.VooPartidaNavigations)
                .HasForeignKey(d => d.Partida)
                .HasConstraintName("FK__Voo__Partida__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
