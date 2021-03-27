using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupInviteRepository : RepositoryBase<GroupInvite>, IGroupInviteRepository
    {
        public GroupInviteRepository(ShuflContext context) : base(context) { }

        public async Task<GroupInvite> GetByIdentifierAsync(string groupInviteIdentifier)
        {
            return await _ShuflContext.GroupInvites.Where(u => u.Identifier == groupInviteIdentifier).FirstOrDefaultAsync();
        }
    }
}
