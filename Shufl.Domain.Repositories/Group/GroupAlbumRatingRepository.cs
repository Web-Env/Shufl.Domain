using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupAlbumRatingRepository : RepositoryBase<GroupAlbumRating>, IGroupAlbumRatingRepository
    {
        public GroupAlbumRatingRepository(ShuflContext context) : base(context) { }
    }
}
