using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Entities.User>
    {
        Task<Entities.User> FindByUsernameAsync(string username);

        Task<Entities.User> GetFullUserByIdAsync(Guid userId);
    }
}
