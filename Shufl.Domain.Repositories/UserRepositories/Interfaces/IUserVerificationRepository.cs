using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.UserRepositories.Interfaces
{
    public interface IUserVerificationRepository : IRepositoryBase<UserVerification>
    {
        Task<UserVerification> FetchByIdentifier(string verificationIdentifier);
    }
}
