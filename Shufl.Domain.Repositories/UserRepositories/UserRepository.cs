using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Contexts;
using Shufl.Domain.Repositories.UserRepositories.Interfaces;

namespace Shufl.Domain.Repositories.UserRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ShuflRepositoryContext context) : base(context) { }
    }
}
