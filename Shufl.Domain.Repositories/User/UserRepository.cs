using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.User.Interfaces;
using System;
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

        public async Task<Entities.User> GetFullUserByIdAsync(Guid userId)
        {
            return await _ShuflContext.Users.Include(u => u.UserImages).Where(u => u.Id == userId).FirstOrDefaultAsync();
        }
    }
}
