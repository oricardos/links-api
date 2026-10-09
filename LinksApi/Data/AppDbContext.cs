using LinksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Link> Links { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
                Define como as propriedades das suas entidades
                serão representadas no banco de dados
             
                HasKey = chave primária
                IsRequired = coluna não pode receber null
                HasMaxLength = define o tamanho máximo da coluna
                HasIndex = cria um índice para a propriedade indicada
                IsUnique = faz com que o índice impeça e-mails duplicados

            */

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasOne(l => l.Usuario)
                    .WithMany(u => u.Links)
                    .HasForeignKey(l => l.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Categoria>()
                    .WithMany()
                    .HasForeignKey(l => l.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasOne(c => c.Usuario)
                    .WithMany(u => u.Categorias)
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);               
                entity.Property(u => u.Nome)            
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.HasIndex(u => u.Email)
                    .IsUnique();
                entity.Property(u => u.SenhaHash)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(u => u.DataCriacao)
                    .IsRequired();
                entity.Property(u => u.Ativo)
                    .IsRequired();
            });
        }
    }
}
