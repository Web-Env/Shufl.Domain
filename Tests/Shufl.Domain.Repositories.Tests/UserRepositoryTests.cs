using Shufl.Domain.Repositories.User;
using System;
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
            var context = RepositoryTestHelper.CreateMockContext<Entities.User>();
            var repository = new UserRepository(context.Object);

            //Act
            var fetchedUser = await repository.GetByIdAsync(Guid.NewGuid());

            //Assert
            Assert.NotNull(fetchedUser);
            Assert.IsAssignableFrom<Entities.User>(fetchedUser);
        }
    }
}
