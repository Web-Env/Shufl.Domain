using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.Spotify.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Spotify
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(ShuflContext context) : base(context) { }

        public async Task<Genre> GetByCodeAsync(string code)
        {
            return await _ShuflContext.Genres.Where(g => g.Code == code).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Genre>> GetManyByCodeAsync(IEnumerable<string> codes)
        {
            return await _ShuflContext.Genres.Where(g => codes.Contains(g.Code)).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetManyCodesByCodeAsync(IEnumerable<string> codes)
        {
            return await _ShuflContext.Genres.Where(g => codes.Contains(g.Code)).Select(g => g.Code).ToListAsync();
        }
    }
}
