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
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumImages)
                .Include(gs => gs.GroupSuggestionRatings)
                    .ThenInclude(gsr => gsr.CreatedByNavigation)
                .Include(gs => gs.CreatedByNavigation)
                .OrderByDescending(gs => gs.CreatedOn)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GroupSuggestion> GetByIdentifierAndGroupIdentifierAsync(string groupSuggestionIdentifier, string groupIdentifier)
        {
            return await _ShuflContext.GroupSuggestions.Where(gs => gs.Identifier == groupSuggestionIdentifier && gs.Group.Identifier == groupIdentifier)
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                            .ThenInclude(a => a.ArtistGenres)
                                .ThenInclude(ag => ag.Genre)
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumImages)
                .Include(gs => gs.GroupSuggestionRatings)
                    .ThenInclude(gsr => gsr.CreatedByNavigation)
                .Include(gs => gs.CreatedByNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
        public async Task<GroupSuggestion> CheckExistsByIdentifierAndGroupIdAsync(string groupSuggestionIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupSuggestions.Where(gs =>
                gs.Identifier == groupSuggestionIdentifier &&
                gs.GroupId == groupId).FirstOrDefaultAsync();
        }
    }
}
