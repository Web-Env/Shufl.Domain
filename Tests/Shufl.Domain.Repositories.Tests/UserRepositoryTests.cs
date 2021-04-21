using Moq;
using Shufl.Domain.Repositories.User;
using Shufl.Domain.Repositories.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public async Task GetManyById_ShouldReturnManyUsers()
        {
            //Arrange
            var userCollection = new List<Entities.User>
            {
                new Entities.User()
            };
            var guidList = new List<Guid> { Guid.NewGuid() };

            var repository = new Mock<IUserRepository>();
            repository.Setup(r => r.GetManyByIdAsync(guidList)).Returns(Task.FromResult(userCollection.AsEnumerable()));

            //Act
            var fetchedUsers = await repository.Object.GetManyByIdAsync(guidList);

            //Assert
            Assert.NotNull(fetchedUsers);
            Assert.IsAssignableFrom<IEnumerable<Entities.User>>(fetchedUsers);
        }

        [Fact]
        public async Task GetPage_ShouldReturnManyUsers()
        {
            //Arrange
            var userCollection = new List<Entities.User>
            {
                new Entities.User()
            };
            var guidList = new List<Guid> { Guid.NewGuid() };

            var repository = new Mock<IUserRepository>();
            repository.Setup(r => r.GetPageAsync(0, 1)).Returns(Task.FromResult(userCollection.AsEnumerable()));

            //Act
            var fetchedPage = await repository.Object.GetPageAsync(0, 1);

            //Assert
            Assert.NotNull(fetchedPage);
            Assert.IsAssignableFrom<IEnumerable<Entities.User>>(fetchedPage);
        }
    }
}
