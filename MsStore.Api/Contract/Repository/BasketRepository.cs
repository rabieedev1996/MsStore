

using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository;

public class BasketRepository : BaseRepository<BasketEntity>, IBasketRepository
{
    public BasketRepository(SQLContext dbContext) : base(dbContext)
    {
    }

  
}