using Shufl.Domain.Entities;

namespace Shufl.Domain.Repositories.UserRepositories
{
    public class UserVerificationRepository : RepositoryBase<UserVerification>, IUserVerificationRepository
    {
        public UserVerificationRepository(ShuflContext context) : base(context) { }
    }
}
