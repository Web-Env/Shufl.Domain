﻿using Microsoft.EntityFrameworkCore;
using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.UserRepositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.UserRepositories
{
    public class UserVerificationRepository : RepositoryBase<UserVerification>, IUserVerificationRepository
    {
        public UserVerificationRepository(ShuflContext context) : base(context) { }

        public async Task<UserVerification> FetchByIdentifier(string verificationIdentifier)
        {
            var userVerification = await _ShuflContext.UserVerifications.Where(uv => 
                uv.VerificationIdentifier == verificationIdentifier).FirstOrDefaultAsync();

            return userVerification;
        }
    }
}
