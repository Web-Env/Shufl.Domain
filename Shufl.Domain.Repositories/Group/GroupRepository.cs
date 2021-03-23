using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupRepository : RepositoryBase<Entities.Group>, IGroupRepository
    {
        public GroupRepository(ShuflContext context) : base(context) { }
    }
}
