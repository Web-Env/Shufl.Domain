using Shufl.Domain.Repositories.Contexts;
using Shufl.Domain.Repositories.Interfaces;
using Shufl.Domain.Repositories.UserRepositories;
using Shufl.Domain.Repositories.UserRepositories.Interfaces;
using System;

namespace Shufl.Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ShuflRepositoryContext _shuflContext;

        public IPasswordResetRepository PasswordResetRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public RepositoryManager(ShuflRepositoryContext context)
        {
            _shuflContext = context;

            PasswordResetRepository = new PasswordResetRepository(_shuflContext);
            UserRepository = new UserRepository(_shuflContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
