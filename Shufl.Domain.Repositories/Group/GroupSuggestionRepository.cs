using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupSuggestionRepository : RepositoryBase<GroupSuggestion>, IGroupSuggestionRepository
    {
        public GroupSuggestionRepository(ShuflContext context) : base(context) { }
    }
}
