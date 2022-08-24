using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using q2ibackend.Data.Models;

namespace q2ibackend.Data.Context
{
    public partial class q2ibackendContext : DbContext
    {
        public q2ibackendContext() { }
        public q2ibackendContext(DbContextOptions<q2ibackendContext> options) : base(options) { }
        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Telefone> Telefones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Database/q2i.db;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("cargo");
                entity.HasIndex(e => e.Id, "IX_cargo_Id").IsUnique();
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa");
                entity.HasIndex(e => e.Id, "IX_empresa_Id").IsUnique();
                entity.Property(e => e.IdEndereco).HasColumnName("Id_Endereco");
                entity.Property(e => e.IdTelefone).HasColumnName("Id_Telefone");
                entity.Property(e => e.Nome).HasColumnType("TEXT(200)");
                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdEndereco);
                entity.HasOne(d => d.IdTelefoneNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdTelefone);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");
                entity.HasIndex(e => e.Id, "IX_endereco_Id").IsUnique();
                entity.Property(e => e.Cep).HasColumnName("CEP");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionario");
                entity.HasIndex(e => e.Id, "IX_funcionario_Id").IsUnique();
                entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");
                entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");
                entity.Property(e => e.Nome).HasColumnType("TEXT(200)");
                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdCargo);
                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdEmpresa);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("telefone");
                entity.HasIndex(e => e.Id, "IX_telefone_Id").IsUnique();
                entity.Property(e => e.Ddd).HasColumnName("DDD");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");
                entity.HasIndex(e => e.Id, "IX_usuario_Id").IsUnique();
                entity.HasIndex(e => e.Username, "IX_usuario_Username").IsUnique();
                entity.Property(e => e.IdFuncionario).HasColumnName("Id_Funcionario");
                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdFuncionario);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
