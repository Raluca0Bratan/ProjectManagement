using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using ProjectManagement.DataAccess.EF;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.Test
{
    //[TestClass]
    //public class StudentRepositoryTest
    //{
    //    private  Mock<ProjectManagementContext> mockContext;
    //    private  Mock<DbSet<Student>> mockDbSet;
    //    private  StudentRepository repository;


    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        var options = new DbContextOptions<ProjectManagementContext>();
    //        mockContext = new Mock<ProjectManagementContext>(options);
    //        mockDbSet = new();

    //        mockContext.Setup(c => c.Set<Student>()).Returns(mockDbSet.Object);

    //    }

    //    [TestMethod] // Raluca
    //    public void HavingAdd_ShouldAddEntityAndSaveChanges()
    //    {
    //        // Arrange
    //        var student = new Student { Id = "123", Name = "John" };
    //        var mockDbSet = new Mock<DbSet<Student>>();
    //        var mockEntityEntry = new Mock<EntityEntry<Student>>();

    //        mockDbSet.Setup(d => d.Add(It.IsAny<Student>())).Returns(mockEntityEntry.Object);
    //        mockEntityEntry.Setup(e => e.Entity).Returns(student);

    //        mockContext.Setup(c => c.Set<Student>()).Returns(mockDbSet.Object);
    //        mockContext.Setup(c => c.SaveChanges()).Returns(1);
    //        // Act
    //        var result = repository.Add(student);

    //        // Assert
    //        mockDbSet.Verify(d => d.Add(student), Times.Once);
    //        mockContext.Verify(c => c.SaveChanges(), Times.Once);
    //        Assert.AreEqual(student, result);
    //    }

    //    [TestMethod] // Raluca
    //    public void Remove_ShouldRemoveEntityAndSaveChanges()
    //    {
    //        // Arrange
    //        var student = new Student { Id = "123", Name = "John" };
    //        repository = new StudentRepository(mockContext.Object);

    //        // Act
    //        repository.Add(student);
    //        repository.Remove(student);

    //        // Assert
    //        mockDbSet.Verify(d => d.Remove(student), Times.Once);
    //        mockContext.Verify(c => c.SaveChanges(), Times.Once);
    //        Assert.ThrowsException<InvalidOperationException>(() => repository.FindByCondition(s => s.Id == "123").First());
    //    }
   // }
}