using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupSuggestionRepository : IRepositoryBase<GroupSuggestion>
    {
        Task<GroupSuggestion> GetByIdentifierAndGroupIdAsync(string groupSuggestionIdentifier, Guid groupId);
    }
}
