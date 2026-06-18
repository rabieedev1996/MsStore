

using MsStore.Api.DTOs;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Interface;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<UserEntity> GetByPhoneNumber(long phoneNumber);
}