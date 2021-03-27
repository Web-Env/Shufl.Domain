using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupMemberRepository : IRepositoryBase<GroupMember>
    {
        Task<GroupMember> GetByUserIdAndGroupIdAsync(Guid userId, Guid groupId);
    }
}
