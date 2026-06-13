using Classicode.Utility;
using Microsoft.EntityFrameworkCore;
using MsStore.Api.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MsStore.Api.Database
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductPropEntity> ProductProps { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var now = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        entry.Entity.Id = Guid.NewGuid();
                        entry.Entity.CreatedAt = now;
                        entry.Entity.NumericCreateAtFa = long.Parse(now.ToFa("yyyyMMddHHmmss"));
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifyDate = now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
