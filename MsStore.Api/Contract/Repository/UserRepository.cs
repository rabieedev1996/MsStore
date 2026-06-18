

using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    public UserRepository(SQLContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserEntity> GetByPhoneNumber(long phoneNumber)
    {
        var user = GetDBSetQuery().FirstOrDefault(a=>a.PhoneNumber==phoneNumber);
        return user;
    }
}