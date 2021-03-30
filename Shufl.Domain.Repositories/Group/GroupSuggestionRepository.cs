using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupSuggestionRepository : RepositoryBase<GroupSuggestion>, IGroupSuggestionRepository
    {
        public GroupSuggestionRepository(ShuflContext context) : base(context) { }

        public async Task<IEnumerable<GroupSuggestion>> GetByGroupIdAsync(Guid groupId)
        {
            return await _ShuflContext.GroupSuggestions.Where(gs => gs.GroupId == groupId)
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                            .ThenInclude(a => a.ArtistGenres)
                                .ThenInclude(ag => ag.Genre)
                .Include(gs => gs.CreatedByNavigation)
                .ToListAsync();
        }

        public async Task<GroupSuggestion> GetByIdentifierAndGroupIdAsync(string groupSuggestionIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupSuggestions.Where(gs =>
                gs.Identifier == groupSuggestionIdentifier &&
                gs.GroupId == groupId).FirstOrDefaultAsync();
        }
    }
}
