using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupAlbumRepository : RepositoryBase<GroupAlbum>, IGroupAlbumRepository
    {
        public GroupAlbumRepository(ShuflContext context) : base(context) { }

        public async Task<IEnumerable<GroupAlbum>> GetByGroupIdAsync(Guid groupId, int page, int pageSize)
        {
            var offset = pageSize * page;

            return await _ShuflContext.GroupAlbums.Where(gs => gs.GroupId == groupId)
                .OrderByDescending(gs => gs.CreatedOn)
                .Skip(offset)
                .Take(pageSize)
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                            .ThenInclude(a => a.ArtistGenres)
                                .ThenInclude(ag => ag.Genre)
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumImages)
                .Include(gs => gs.GroupAlbumRatings)
                    .ThenInclude(gsr => gsr.CreatedByNavigation)
                .Include(gs => gs.CreatedByNavigation)
                    .ThenInclude(u => u.UserImages)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GroupAlbum> GetByIdentifierAndGroupIdAsync(string groupAlbumIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupAlbums.Where(gs => gs.Identifier == groupAlbumIdentifier && gs.Group.Id == groupId)
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                            .ThenInclude(a => a.ArtistGenres)
                                .ThenInclude(ag => ag.Genre)
                .Include(gs => gs.Album)
                    .ThenInclude(a => a.AlbumImages)
                .Include(gs => gs.GroupAlbumRatings)
                    .ThenInclude(gsr => gsr.CreatedByNavigation)
                .Include(gs => gs.CreatedByNavigation)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
        public async Task<GroupAlbum> CheckExistsByIdentifierAndGroupIdAsync(string groupAlbumIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupAlbums.Where(gs =>
                gs.Identifier == groupAlbumIdentifier &&
                gs.GroupId == groupId).FirstOrDefaultAsync();
        }
    }
}
