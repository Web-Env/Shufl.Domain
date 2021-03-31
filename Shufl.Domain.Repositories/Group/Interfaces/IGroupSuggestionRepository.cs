using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Group.Interfaces
{
    public interface IGroupSuggestionRepository : IRepositoryBase<GroupSuggestion>
    {
        Task<IEnumerable<GroupSuggestion>> GetByGroupIdAsync(Guid groupId);

        Task<GroupSuggestion> GetByIdentifierAndGroupIdAsync(string groupSuggestionIdentifier, Guid groupId);

        Task<GroupSuggestion> CheckExistsByIdentifierAndGroupIdAsync(string groupSuggestionIdentifier, Guid groupId);
    }
}
