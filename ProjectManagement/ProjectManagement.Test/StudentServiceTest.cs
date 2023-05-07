using Moq;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;

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
    }
}
