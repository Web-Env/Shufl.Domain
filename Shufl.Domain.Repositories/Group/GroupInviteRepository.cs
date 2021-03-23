using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupInviteRepository : RepositoryBase<GroupInvite>, IGroupInviteRepository
    {
        public GroupInviteRepository(ShuflContext context) : base(context) { }
    }
}
