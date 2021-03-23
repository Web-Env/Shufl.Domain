using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User.Interfaces
{
    public interface IPasswordResetRepository : IRepositoryBase<PasswordReset>
    {
        Task<PasswordReset> FetchByIdentifier(string resetIdentifier);
    }
}
