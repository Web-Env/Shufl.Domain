using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.User.Interfaces
{
    public interface IUserImageRepository : IRepositoryBase<UserImage>
    {
        Task<IEnumerable<UserImage>> GetByUserIdAsync(Guid userId);
    }
}
