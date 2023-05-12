using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectManagement.DataAccess.EF;
using ProjectManagement.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Test
{
    [TestClass]
    public class TeacherRepositoryTests
    {
        private Mock<ProjectManagementContext> mockContext;
        private Mock<DbSet<Teacher>> mockDbSet;
        private TeacherRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptions<ProjectManagementContext>();
            mockContext = new Mock<ProjectManagementContext>(options);
            mockDbSet = new();

            mockContext.Setup(c => c.Set<Teacher>()).Returns(mockDbSet.Object);
        }

        [TestMethod]
        public void RemoveDisciplineFromTeacher_ShouldRemoveDisciplineFromTeacher()
        {
            // Arrange
            var teacher = new Teacher
            {
                Id = "123",
                Disciplines = new List<Discipline>
            {
                new Discipline { Id = Guid.NewGuid(), Name = "Math" },
                new Discipline { Id = Guid.NewGuid(), Name = "English" }
            }
            };
            var disciplineToRemove = teacher.Disciplines.First();

            // Act
            repository.RemoveDisciplineFromTeacher(teacher.Id, disciplineToRemove);

            // Assert
            Assert.AreEqual(1, teacher.Disciplines.Count);
            Assert.IsFalse(teacher.Disciplines.Contains(disciplineToRemove));
        }

        [TestMethod]
        public void RemoveDisciplineFromTeacher_ShouldThrowIfTeacherNotFound()
        {
            // Arrange
            var teacherId = "123";
            var discipline = new Discipline();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => repository.RemoveDisciplineFromTeacher(teacherId, discipline));
        }

        [TestMethod]
        public void RemoveDisciplineFromTeacher_ShouldThrowIfDisciplineNotFound()
        {
            // Arrange
            var teacher = new Teacher
            {
                Id = "123",
                Disciplines = new List<Discipline>
            {
                new Discipline { Id = Guid.NewGuid(), Name = "Math" }
            }
            };
            var disciplineToRemove = new Discipline { Id = Guid.NewGuid(), Name = "English" };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => repository.RemoveDisciplineFromTeacher(teacher.Id, disciplineToRemove));
        }
    }

}
