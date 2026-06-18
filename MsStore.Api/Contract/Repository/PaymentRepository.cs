

using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository;

public class PaymentRepository : BaseRepository<PaymentEntity>, IPaymentRepository
{
    public PaymentRepository(SQLContext dbContext) : base(dbContext)
    {
    }

  
}