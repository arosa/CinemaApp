using CinemaApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data
{
    public class MVCCinemaDBContext : DbContext
    {
        public MVCCinemaDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
