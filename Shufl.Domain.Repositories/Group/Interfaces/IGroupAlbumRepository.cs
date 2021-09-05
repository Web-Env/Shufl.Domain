using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupAlbumRepository : IRepositoryBase<GroupAlbum>
    {
        Task<IEnumerable<GroupAlbum>> GetByGroupIdAsync(Guid groupId, int page, int pageSize);

        Task<int> GetCountByGroupIdAsync(Guid groupId);

        Task<IEnumerable<GroupAlbum>> GetTopThirtyByGroupIdAsync(Guid groupId);

        Task<GroupAlbum> GetByIdentifierAndGroupIdAsync(string groupAlbumIdentifier, Guid groupId);

        Task<GroupAlbum> CheckExistsByIdentifierAndGroupIdAsync(string groupAlbumIdentifier, Guid groupId);
    }
}
