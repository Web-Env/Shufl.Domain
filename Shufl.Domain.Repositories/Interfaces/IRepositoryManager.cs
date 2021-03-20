using Shufl.Domain.Repositories.UserRepositories.Interfaces;
using System;

namespace Shufl.Domain.Repositories.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        IPasswordResetRepository PasswordResetRepository { get; }

        IUserRepository UserRepository { get; }
    }
}
