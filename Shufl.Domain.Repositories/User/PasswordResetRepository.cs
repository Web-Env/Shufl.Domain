using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.User.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User
{
    public class PasswordResetRepository : RepositoryBase<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(ShuflContext context) : base(context) { }

        public async Task<PasswordReset> FetchByIdentifier(string resetIdentifier)
        {
            var passwordReset = await _ShuflContext.PasswordResets.Where(pr =>
                pr.Identifier == resetIdentifier).FirstOrDefaultAsync();

            return passwordReset;
        }
    }
}
