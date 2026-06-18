

using MsStore.Api.Contract.Interface;
using MsStore.Api.Database;
using MsStore.Api.Models;

namespace MsStore.Api.Contract.Repository;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    public UserRepository(SQLContext dbContext) : base(dbContext)
    {
    }
}