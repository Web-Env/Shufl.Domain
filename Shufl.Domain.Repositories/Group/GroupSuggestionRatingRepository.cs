using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupSuggestionRatingRepository : RepositoryBase<GroupSuggestionRating>, IGroupSuggestionRatingRepository
    {
        public GroupSuggestionRatingRepository(ShuflDbContext context) : base(context) { }
    }
}
