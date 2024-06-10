using System.Collections.Generic;
using System.Reflection.Emit;

using Microsoft.EntityFrameworkCore;

using MY_WEB_APP.Models;

namespace MY_WEB_APP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RawData> RawData { get; set; }
        public DbSet<TransformedData> TransformedData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configuration if needed
            modelBuilder.Entity<RawData>().ToTable("RawData");
            modelBuilder.Entity<TransformedData>().ToTable("TransformedData");
        }
    }
}
