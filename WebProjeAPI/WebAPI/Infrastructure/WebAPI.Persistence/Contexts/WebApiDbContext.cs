using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Entities.Common;

namespace WebAPI.Persistence.Contexts
{
    public class WebApiDbContext:DbContext
    {
        public WebApiDbContext(DbContextOptions options):base(options)
        {}
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p =>p.UserName)
                .IsUnique(true);
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryName)
                .IsUnique(true);
            modelBuilder.Entity<Role>()
                .HasIndex(r=>r.RoleName)
                .IsUnique(true);
           
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };

            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
