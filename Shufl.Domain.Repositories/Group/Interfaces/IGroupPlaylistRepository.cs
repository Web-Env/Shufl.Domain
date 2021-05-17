using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupPlaylistRepository : IRepositoryBase<GroupPlaylist>
    {
        Task<IEnumerable<GroupPlaylist>> GetByGroupIdAsync(Guid groupId, int page, int pageSize);

        Task<GroupPlaylist> GetByIdentifierAndGroupIdAsync(string groupPlaylistIdentifier, Guid groupId);

        Task<GroupPlaylist> CheckExistsByIdentifierAndGroupIdAsync(string groupPlaylistIdentifier, Guid groupId);
    }
}
