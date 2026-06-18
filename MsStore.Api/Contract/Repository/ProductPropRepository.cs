using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository
{
    public class ProductPropRepository : BaseRepository<ProductPropEntity>, IProductPropRepository
    {
        public ProductPropRepository(SQLContext dbContext) : base(dbContext)
        {
        }    
    }
}
