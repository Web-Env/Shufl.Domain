using Shufl.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Entities.User>
    {
        Task<Entities.User> FindByUsernameAsync(string username);
    }
}
