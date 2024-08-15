using Coffee.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News => Set<News>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Property(e => e.Created).HasDefaultValueSql("now()");

            builder.Entity<News>().Property(e => e.Date).HasDefaultValueSql("now()");
            builder.Entity<News>().Property(e => e.CreateDate).HasDefaultValueSql("now()");
            builder.Entity<News>().Property(e => e.IsActive).HasDefaultValue(true);

        }
    }
}