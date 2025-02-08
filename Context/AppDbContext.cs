using Memo.Models;
using Microsoft.EntityFrameworkCore;

namespace Memo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Music> Musics { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Musics)
                .WithOne(m => m.Playlist)
                .HasForeignKey(m => m.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
