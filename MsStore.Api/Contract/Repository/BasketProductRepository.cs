


using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository;

public class BasketProductRepository : BaseRepository<BasketProductEntity>, IBasketProductRepository
{
    public BasketProductRepository(SQLContext dbContext) : base(dbContext)
    {
    }

  
}