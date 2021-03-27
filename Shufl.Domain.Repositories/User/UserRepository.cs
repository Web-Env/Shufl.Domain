using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.User.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User
{
    public class UserRepository : RepositoryBase<Entities.User>, IUserRepository
    {
        public UserRepository(ShuflContext context) : base(context) { }

        public async Task<Entities.User> FindByUsernameAsync(string username)
        {
            return await _ShuflContext.Users.Where(u => u.Username == username.ToLower()).FirstOrDefaultAsync();
        }
    }
}
