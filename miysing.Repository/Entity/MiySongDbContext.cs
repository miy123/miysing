using Microsoft.EntityFrameworkCore;

namespace miysing.Repository
{
    public class MiySongDbContext : DbContext
    {
        public MiySongDbContext(DbContextOptions<MiySongDbContext> options) : base(options)
        {
        }

        public MiySongDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<SongRecord> SongRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
