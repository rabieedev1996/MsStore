using Classicode.Utility;
using Microsoft.EntityFrameworkCore;
using MsStore.Api.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;

namespace MsStore.Api.Database
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductPropEntity> ProductProps { get; set; }
        public DbSet<BasketEntity> Baskets { get; set; }
        public DbSet<BasketProductEntity> BasketProducts { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }


        public override int SaveChanges()
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
            return base.SaveChanges();
        }

       
    }
}
