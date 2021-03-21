using Shufl.Domain.Entities;
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
        public IUserVerificationRepository UserVerificationRepository { get; private set; }

        public RepositoryManager(ShuflContext context)
        {
            PasswordResetRepository = new PasswordResetRepository(context);
            UserRepository = new UserRepository(context);
            UserVerificationRepository = new UserVerificationRepository(context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
