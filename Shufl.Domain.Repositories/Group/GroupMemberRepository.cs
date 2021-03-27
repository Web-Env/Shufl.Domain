using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupMemberRepository : RepositoryBase<GroupMember>, IGroupMemberRepository
    {
        public GroupMemberRepository(ShuflContext context) : base (context) { }

        public async Task<GroupMember> GetByUserIdAndGroupIdAsync(Guid userId, Guid groupId)
        {
            return await _ShuflContext.GroupMembers.Where(gm =>
                gm.UserId == userId &&
                gm.GroupId == groupId).FirstOrDefaultAsync();
        }
    }
}
