using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.AutoPeças.WebApi.Domains
{
    public partial class EkipsContext : DbContext
    {
        public EkipsContext()
        {
        }

        public EkipsContext(DbContextOptions<EkipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Pecas> Pecas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_AutoPecas;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Forneced__A299CC92BA78CA3B")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fornecedores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Fornecedo__IdUsu__4CA06362");
            });

            modelBuilder.Entity<Pecas>(entity =>
            {
                entity.HasKey(e => e.IdPecas);

                entity.HasIndex(e => e.CodigoPeca)
                    .HasName("UQ__Pecas__B9F4770F5A068506")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Peso)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoCusto)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoVenda)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__Pecas__IdFornece__5070F446");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });
        }
    }
}
