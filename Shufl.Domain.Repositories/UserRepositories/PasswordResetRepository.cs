using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.UserRepositories.Interfaces;

namespace Shufl.Domain.Repositories.UserRepositories
{
    public class PasswordResetRepository : RepositoryBase<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(ShuflContext context) : base(context) { }
    }
}
