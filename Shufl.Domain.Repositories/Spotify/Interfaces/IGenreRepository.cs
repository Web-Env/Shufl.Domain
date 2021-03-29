using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify.Interfaces
{
    public interface IGenreRepository : IRepositoryBase<Genre>
    {
        Task<Genre> GetByCodeAsync(string code);

        Task<IEnumerable<Genre>> GetManyByCodeAsync(IEnumerable<string> codes);

        Task<IEnumerable<string>> GetManyCodesByCodeAsync(IEnumerable<string> codes);
    }
}
