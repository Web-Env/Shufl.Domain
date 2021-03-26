using Shufl.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupRepository : IRepositoryBase<Entities.Group>
    {
        Task<Entities.Group> GetByIdentifier(string groupIdentifier);
    }
}
