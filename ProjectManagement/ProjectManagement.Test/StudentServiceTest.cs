using Moq;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;
using System.Linq.Expressions;

namespace ProjectManagement.Test
{
    [TestClass]
    public class StudentServiceTest
    {
        private Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
        private StudentService studentService;

        [TestMethod]  // Raluca
        public void HavingGetStudents_WhenThereIsAListOfStudents_ShouldReturnAllStudents()
        {
            studentService = new(mockRepository.Object);
            // Arrange
            var students = new List<Student>
        {
            new Student { Id = "1", Name = "John" },
            new Student { Id = "2", Name = "Jane" },
            new Student { Id = "3", Name = "Alice" }
        };
            mockRepository.Setup(r => r.GetAll()).Returns(students);

            // Act
            var result = studentService.GetStudents();

            // Assert
            Assert.AreEqual(students.Count, result.Count());
            CollectionAssert.AreEqual(students, result.ToList());
        }

        [TestMethod]
        public void HavingAddStudent_ShouldCallRepositoryAdd()
        {
            // Arrange
            var student = new Student { Id = "1", Name = "John" };

            // Act
            studentService.AddStudent(student);

            // Assert
            mockRepository.Verify(r => r.Add(student), Times.Once);
            
        }

        [TestMethod]
        public void HavingRemoveStudent_WithExistingStudentId_ShouldCallRepositoryRemove()
        {
            // Arrange
            var studentId = "1";
            var student = new Student { Id = studentId, Name = "John" };

            mockRepository.Setup(r => r.FindByCondition(It.IsAny<Expression<Func<Student, bool>>>())).Returns(new List<Student> { student }.AsQueryable());

            // Act
            studentService.RemoveStudent(studentId);

            // Assert
            mockRepository.Verify(r => r.FindByCondition(It.IsAny<Expression<Func<Student, bool>>>()), Times.Once);
            mockRepository.Verify(r => r.Remove(student), Times.Once);
           
        }
    }
}
