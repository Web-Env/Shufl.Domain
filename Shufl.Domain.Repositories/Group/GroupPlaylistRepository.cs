using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupPlaylistRepository : RepositoryBase<GroupPlaylist>, IGroupPlaylistRepository
    {
        public GroupPlaylistRepository(ShuflContext context) : base(context) { }

        public async Task<IEnumerable<GroupPlaylist>> GetByGroupIdAsync(Guid groupId, int page, int pageSize)
        {
            var offset = pageSize * page;

            return await _ShuflContext.GroupPlaylists.Where(gp => gp.GroupId == groupId)
                .OrderByDescending(gp => gp.CreatedOn)
                .Skip(offset)
                .Take(pageSize)
                .Include(gp => gp.Playlist)
                    .ThenInclude(p => p.PlaylistImages)
                .Include(gp => gp.GroupPlaylistRatings)
                    .ThenInclude(gpr => gpr.CreatedByNavigation)
                .Include(gp => gp.CreatedByNavigation)
                    .ThenInclude(u => u.UserImages)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GroupPlaylist> GetByIdentifierAndGroupIdAsync(string groupPlaylistIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupPlaylists.Where(gp => gp.Identifier == groupPlaylistIdentifier && gp.Group.Id == groupId)
                .Include(gp => gp.Playlist)
                    .ThenInclude(p => p.PlaylistImages)
                .Include(gp => gp.GroupPlaylistRatings)
                    .ThenInclude(gpr => gpr.CreatedByNavigation)
                .Include(gp => gp.CreatedByNavigation)
                    .ThenInclude(u => u.UserImages)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<GroupPlaylist> CheckExistsByIdentifierAndGroupIdAsync(string groupPlaylistIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupPlaylists.Where(gp =>
                gp.Identifier == groupPlaylistIdentifier &&
                gp.GroupId == groupId).FirstOrDefaultAsync();
        }
    }
}
