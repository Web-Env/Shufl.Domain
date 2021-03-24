using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User.Interfaces
{
    public interface IUserVerificationRepository : IRepositoryBase<UserVerification>
    {
        Task<UserVerification> FindByIdentifierAsync(string verificationIdentifier);
    }
}
