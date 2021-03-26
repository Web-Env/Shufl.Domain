using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupRepository : RepositoryBase<Entities.Group>, IGroupRepository
    {
        public GroupRepository(ShuflContext context) : base(context) { }

        public async Task<Entities.Group> GetByIdentifier(string groupIdentifier)
        {
            return await _ShuflContext.Groups.Where(u => u.Identifier == groupIdentifier).FirstOrDefaultAsync();
        }
    }
}
