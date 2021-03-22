using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.User.Interfaces;

namespace Shufl.Domain.Repositories.User
{
    public class UserRepository : RepositoryBase<Entities.User>, IUserRepository
    {
        public UserRepository(ShuflContext context) : base(context) { }
    }
}
