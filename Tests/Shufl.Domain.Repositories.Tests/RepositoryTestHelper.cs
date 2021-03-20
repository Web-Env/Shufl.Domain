using Microsoft.EntityFrameworkCore;
using Moq;
using Shufl.Domain.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shufl.Domain.Repositories.Tests
{
    public static class RepositoryTestHelper
    {
        public static Mock<ShuflRepositoryContext> CreateMockContext<T>() where T : class
        {
            var shuflContextMock = SetupDbContext();
            var dbSetMock = SetupDbSetMock<T>();

            dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).Returns(ValueTask.FromResult((T)Activator.CreateInstance(typeof(T))));

            shuflContextMock.Setup(s => s.Set<T>()).Returns(dbSetMock.Object);

            return shuflContextMock;
        }

        public static Mock<ShuflRepositoryContext> CreateMockContext<T>(IEnumerable<T> entityCollection) where T : class
        {
            var shuflContextMock = SetupDbContext();
            var dbSetMock = SetupDbSetMock<T>();

            IQueryable<T> queryableList = entityCollection.AsQueryable();

            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());

            shuflContextMock.Setup(s => s.Set<T>()).Returns(dbSetMock.Object);

            return shuflContextMock;
        }

        private static Mock<ShuflRepositoryContext> SetupDbContext()
        {
            Mock<ShuflRepositoryContext> shuflContextMock = new Mock<ShuflRepositoryContext>(
                new DbContextOptions<ShuflRepositoryContext>());

            return shuflContextMock;
        }

        private static Mock<DbSet<T>> SetupDbSetMock<T>() where T : class
        {
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();

            return dbSetMock;
        }
    }
}
