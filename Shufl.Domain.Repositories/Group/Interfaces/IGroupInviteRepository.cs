using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupInviteRepository : IRepositoryBase<GroupInvite>
    {
        Task<GroupInvite> GetByIdentifierAsync(string groupInviteIdentifier);
    }
}
