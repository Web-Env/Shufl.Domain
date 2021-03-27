using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupMemberRepository : RepositoryBase<GroupMember>, IGroupMemberRepository
    {
        public GroupMemberRepository(ShuflContext context) : base (context) { }
    }
}
