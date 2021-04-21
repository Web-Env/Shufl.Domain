using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User
{
    public class UserImageRepository : RepositoryBase<UserImage>, IUserImageRepository
    {
        public UserImageRepository(ShuflContext context) : base(context) { }

        public async Task<IEnumerable<UserImage>> GetByUserIdAsync(Guid userId)
        {
            return await _ShuflContext.Set<UserImage>().Where(us => us.UserId == userId).ToListAsync();
        }
    }
}
