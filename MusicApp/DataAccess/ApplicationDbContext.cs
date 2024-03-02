using Microsoft.EntityFrameworkCore;
using MusicApp.Models;

namespace MusicApp.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<MovieSearch> MovieSearches { get; set; }
    }
}