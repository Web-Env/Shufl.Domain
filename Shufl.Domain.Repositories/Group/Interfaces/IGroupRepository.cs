using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupRepository : IRepositoryBase<Entities.Group>
    {
        Task<Entities.Group> GetByIdentifierAsync(string groupIdentifier);

        Task<Entities.Group> GetByIdForDownloadAsync(Guid groupId);

        Task<List<Entities.Group>> GetManyByIdForDownloadAsync(IEnumerable<Guid> ids);
    }
}
