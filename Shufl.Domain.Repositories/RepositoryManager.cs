using Shufl.Domain.Repositories.Contexts;
using Shufl.Domain.Repositories.Interfaces;
using Shufl.Domain.Repositories.UserRepositories;
using Shufl.Domain.Repositories.UserRepositories.Interfaces;
using System;

namespace Shufl.Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public RepositoryManager(ShuflRepositoryContext context)
        {
            PasswordResetRepository = new PasswordResetRepository(context);
            UserRepository = new UserRepository(context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
