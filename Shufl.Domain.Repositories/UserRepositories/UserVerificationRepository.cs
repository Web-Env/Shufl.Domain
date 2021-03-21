using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.UserRepositories.Interfaces;

namespace Shufl.Domain.Repositories.UserRepositories
{
    public class UserVerificationRepository : RepositoryBase<UserVerification>, IUserVerificationRepository
    {
        public UserVerificationRepository(ShuflContext context) : base(context) { }
    }
}
