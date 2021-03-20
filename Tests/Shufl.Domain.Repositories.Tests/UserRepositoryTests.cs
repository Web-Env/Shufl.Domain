using Shufl.Domain.Entities;
using Shufl.Domain.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Shufl.Domain.Repositories.Tests
{
    [Trait("Category", "Unit")]
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetById_ShouldReturnSingleUser()
        {
            //Arrange
            var context = RepositoryTestHelper.CreateMockContext<User>();
            var repository = new UserRepository(context.Object);

            //Act
            var fetchedUser = await repository.GetByIdAsync(Guid.NewGuid());

            //Assert
            Assert.NotNull(fetchedUser);
            Assert.IsAssignableFrom<User>(fetchedUser);
        }
    }
}
