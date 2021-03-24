using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.User.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User
{
    public class UserVerificationRepository : RepositoryBase<UserVerification>, IUserVerificationRepository
    {
        public UserVerificationRepository(ShuflContext context) : base(context) { }

        public async Task<UserVerification> FindByIdentifierAsync(string verificationIdentifier)
        {
            var userVerification = await _ShuflContext.UserVerifications.Where(uv => 
                uv.Identifier == verificationIdentifier).FirstOrDefaultAsync();

            return userVerification;
        }
    }
}
