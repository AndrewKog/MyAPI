using Microsoft.EntityFrameworkCore;
 
namespace MyAPI.Data
{
    public class DataContext:DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Match> Match => Set<Match>();

        public DbSet<MatchOdd> MatchOdd => Set<MatchOdd>();

    }
}
