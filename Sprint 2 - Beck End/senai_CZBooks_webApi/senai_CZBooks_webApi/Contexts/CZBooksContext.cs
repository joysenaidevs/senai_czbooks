using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_CZBooks_webApi.Domains;

#nullable disable

namespace senai_CZBooks_webApi.Contexts
{
    public partial class CZBooksContext : DbContext
    {
        public CZBooksContext()
        {
        }

        public CZBooksContext(DbContextOptions<CZBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Biblioteca> Bibliotecas { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<TipoLivro> TipoLivros { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                // string de conexao NEIDE
                //optionsBuilder.UseSqlServer("Data Source=WINDOWS\\SQLEXPRESS; initial catalog=CZBooks; user Id=sa; pwd=adm@132;");

                // string de conexao SENAI
                optionsBuilder.UseSqlServer("Data Source=LAB08DESK2601\\SQLEXPRESS01; initial catalog=CZBooks; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__autor__9AE8206A85426E64");

                entity.ToTable("autor");

                entity.HasIndex(e => e.NomeAutor, "UQ__autor__5D4F965E32F7ACB6")
                    .IsUnique();

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.IdLivro).HasColumnName("idLivro");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeAutor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeAutor");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.Autors)
                    .HasForeignKey(d => d.IdLivro)
                    .HasConstraintName("FK__autor__idLivro__47DBAE45");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Autors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__autor__idUsuario__48CFD27E");
            });

            modelBuilder.Entity<Biblioteca>(entity =>
            {
                entity.HasKey(e => e.IdBiblioteca)
                    .HasName("PK__bibliote__E7C768B6B2250D53");

                entity.ToTable("bibliotecas");

                entity.HasIndex(e => e.Endereco, "UQ__bibliote__9456D40655BEBD46")
                    .IsUnique();

                entity.Property(e => e.IdBiblioteca).HasColumnName("idBiblioteca");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeBiblioteca)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeBiblioteca");
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PK__livros__63C546D76A5FAFD8");

                entity.ToTable("livros");

                entity.HasIndex(e => e.Sinopse, "UQ__livros__C5DC17F20A47D5D6")
                    .IsUnique();

                entity.Property(e => e.IdLivro).HasColumnName("idLivro");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.DataPublicacao)
                    .HasColumnType("date")
                    .HasColumnName("dataPublicacao");

                entity.Property(e => e.IdBiblioteca).HasColumnName("idBiblioteca");

                entity.Property(e => e.IdTipoLivro).HasColumnName("idTipoLivro");

                entity.Property(e => e.NomeLivro)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeLivro");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("preco");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("sinopse");

                entity.HasOne(d => d.IdBibliotecaNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdBiblioteca)
                    .HasConstraintName("FK__livros__idBiblio__440B1D61");

                entity.HasOne(d => d.IdTipoLivroNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdTipoLivro)
                    .HasConstraintName("FK__livros__idTipoLi__4316F928");
            });

            modelBuilder.Entity<TipoLivro>(entity =>
            {
                entity.HasKey(e => e.IdTipoLivro)
                    .HasName("PK__tipoLivr__20C38C01D4E451F5");

                entity.ToTable("tipoLivros");

                entity.Property(e => e.IdTipoLivro).HasColumnName("idTipoLivro");

                entity.Property(e => e.TituloTipoLivro)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoLivro");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tiposUsu__03006BFF3B85B02E");

                entity.ToTable("tiposUsuarios");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__tiposUsu__C6B29FC319669942")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__645723A6801DA048");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164526239C9")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuarios__idTipo__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
