using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VideoGames.Models;

namespace VideoGames.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase("VideoGameDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "Cyberpunk 2077", Developer = "CD Projekt Red", ReleaseYear = 2020 },
                new VideoGame { Id = 2, Title = "Elden Ring", Developer = "FromSoftware", ReleaseYear = 2022 },
                new VideoGame { Id = 3, Title = "Red Dead Redemption 2", Developer = "Rockstar", ReleaseYear = 2018 }
                );
        }

        public DbSet<VideoGame> VideoGames { get; set; }

       
    }
}
