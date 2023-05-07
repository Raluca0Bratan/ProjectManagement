using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManagement.DataAccess.EF;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.Test
{
    [TestClass]
    public class StudentRepositoryTest
    {
        private  Mock<DbContext> mockContext;
        private  Mock<DbSet<Student>> mockDbSet;
        private  StudentRepository repository;


        [TestInitialize]
        public void Initialize()
        {
            mockContext = new();
            mockDbSet = new();

            mockContext.Setup(c => c.Set<Student>()).Returns(mockDbSet.Object);

        }

        [TestMethod] // Raluca
        public void Add_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var student = new Student { Id = "123", Name = "John" };
            repository = new StudentRepository(mockContext.Object);
            // Act
            var result = repository.Add(student);

            // Assert
            mockDbSet.Verify(d => d.Add(student), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.AreEqual(student, result);
        }

        [TestMethod] // Raluca
        public void Remove_ShouldRemoveEntityAndSaveChanges()
        {
            // Arrange
            var student = new Student { Id = "123", Name = "John" };
            repository = new StudentRepository(mockContext.Object);

            // Act
            repository.Add(student);
            repository.Remove(student);

            // Assert
            mockDbSet.Verify(d => d.Remove(student), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.ThrowsException<InvalidOperationException>(() => repository.FindByCondition(s => s.Id == "123").First());
        }
    }
}