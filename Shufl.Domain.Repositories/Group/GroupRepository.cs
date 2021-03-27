using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group
{
    public class GroupRepository : RepositoryBase<Entities.Group>, IGroupRepository
    {
        public GroupRepository(ShuflDbContext context) : base(context) { }

        public async Task<Entities.Group> GetByIdentifierAsync(string groupIdentifier)
        {
            return await _ShuflContext.Groups.Where(u => u.Identifier == groupIdentifier).FirstOrDefaultAsync();
        }

        public async Task<Entities.Group> GetByIdForDownloadAsync(Guid groupId)
        {
            return await _ShuflContext.Groups
                .Where(x => x.Id == groupId)
                .Include(g => g.CreatedByNavigation)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Entities.Group>> GetManyByIdForDownloadAsync(IEnumerable<Guid> groupIds)
        {
            return await _ShuflContext.Groups
                .Where(x => groupIds.Contains(EF.Property<Guid>(x, "Id")))
                .Include(g => g.CreatedByNavigation)
                .ToListAsync();
        }
    }
}
