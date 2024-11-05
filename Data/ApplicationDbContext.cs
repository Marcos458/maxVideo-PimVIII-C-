using maxVideo1.Model;
using Microsoft.EntityFrameworkCore;

namespace maxVideo1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
            public required DbSet<UsuarioModel> Users { get; set; }
            public required DbSet<PlaylistModel> Playlists { get; set; }
            public required DbSet<ConteudoModel> Conteudos { get; set; }
            public required DbSet<CriadorModel> Criadores { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UsuarioModel>()
                            .HasMany(u => u.Playlist)
                            .WithOne(p => p.User)
                            .HasForeignKey(p => p.Id);


                modelBuilder.Entity<PlaylistModel>()
                            .HasMany(p => p.Conteudos)
                            .WithOne(c => c.Playlist)
                            .HasForeignKey(c => c.Id)
                            .IsRequired(false); // Configuração para chave estrangeira opcional


                modelBuilder.Entity<ConteudoModel>()
                             .HasOne(c => c.Conteudo)
                             .WithOne(c => c.Criador)
                             .HasForeignKey<ConteudoModel>(p => p.CriadorId);


                base.OnModelCreating(modelBuilder);
            }
        
    }
}

