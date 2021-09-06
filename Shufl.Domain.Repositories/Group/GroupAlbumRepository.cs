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

            return await _ShuflContext.GroupAlbums.Where(ga => ga.GroupId == groupId)
                .OrderByDescending(ga => ga.CreatedOn)
                .Skip(offset)
                .Take(pageSize)
                .Include(ga => ga.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                            .ThenInclude(a => a.ArtistGenres)
                                .ThenInclude(ag => ag.Genre)
                .Include(ga => ga.Album)
                    .ThenInclude(a => a.AlbumImages)
                .Include(ga => ga.GroupAlbumRatings)
                    .ThenInclude(gsr => gsr.CreatedByNavigation)
                .Include(ga => ga.CreatedByNavigation)
                    .ThenInclude(u => u.UserImages)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetCountByGroupIdAsync(Guid groupId)
        {
            return await _ShuflContext.GroupAlbums.Where(ga => ga.GroupId == groupId)
                .CountAsync();
        }

        public async Task<IEnumerable<GroupAlbum>> GetTopThirtyByGroupIdAsync(Guid groupId)
        {
            return await _ShuflContext.GroupAlbums.Where(ga => ga.GroupId == groupId)
                .OrderByDescending(ga => ga.GroupAlbumRatings.Average(gar => gar.OverallRating))
                .Take(30)
                .Include(ga => ga.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GroupAlbum> GetByIdentifierAndGroupIdAsync(string groupAlbumIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupAlbums.Where(ga => ga.Identifier == groupAlbumIdentifier && ga.Group.Id == groupId)
                .Include(ga => ga.Album)
                    .ThenInclude(a => a.AlbumArtists)
                        .ThenInclude(aa => aa.Artist)
                            .ThenInclude(a => a.ArtistGenres)
                                .ThenInclude(ag => ag.Genre)
                .Include(ga => ga.Album)
                    .ThenInclude(a => a.AlbumImages)
                .Include(ga => ga.GroupAlbumRatings)
                    .ThenInclude(gsr => gsr.CreatedByNavigation)
                .Include(ga => ga.RelatedGroupAlbum)
                    .ThenInclude(rga => rga.Album)
                .Include(ga => ga.CreatedByNavigation)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
        public async Task<GroupAlbum> CheckExistsByIdentifierAndGroupIdAsync(string groupAlbumIdentifier, Guid groupId)
        {
            return await _ShuflContext.GroupAlbums.Where(ga =>
                ga.Identifier == groupAlbumIdentifier &&
                ga.GroupId == groupId).FirstOrDefaultAsync();
        }
    }
}
