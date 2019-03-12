using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace miysing.Models
{
    public class MiySongDbContext : DbContext
    {
        public MiySongDbContext(DbContextOptions<MiySongDbContext> options)
            : base(options)
        {
        }

        public MiySongDbContext()
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<SongRecord> SongRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("dbsetting.json")
              .Build();
                var connectionString = configuration.GetConnectionString("DBConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
