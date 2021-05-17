using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupPlaylistRatingRepository : RepositoryBase<GroupPlaylistRating>, IGroupPlaylistRatingRepository
    {
        public GroupPlaylistRatingRepository(ShuflContext context) : base(context) { }
    }
}
