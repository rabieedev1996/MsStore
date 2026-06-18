using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(SQLContext dbContext) : base(dbContext)
        {
        }

        public List<ProductEntity> GetProducts(ProductsRequest filter)
        {
            var productsQuery = GetDBSetQuery();
            if (!string.IsNullOrEmpty(filter.Title))
            {
                productsQuery = productsQuery.Where(a => a.Title.Contains(filter.Title));
            }
            var products = productsQuery.OrderByDescending(a => a.CreatedAt).Skip(filter.From).Take(filter.Count).ToList();
            return products;
        }
    }
}
