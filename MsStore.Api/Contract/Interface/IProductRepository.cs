using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Interface
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        List<ProductEntity> GetProducts(ProductsRequest filter);
    }
}
