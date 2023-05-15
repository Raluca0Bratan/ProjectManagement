

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagement.Controllers;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;
using ProjectManagement.Logic.Interfaces;

namespace ProjectManagement.Test
{
    [TestClass]
    public class StudentControllerTest
    {
        [TestMethod]
        public void HavingControllerExecuteActionIndex_ThenReturnsViewWithStudents()
        {
            // Arrange
            var mockStudentService = new Mock<IStudentService>();
            var mockUserManager = new Mock<UserManager<User>>();
            var students = new List<Student>
    {
        new Student { Id = "1", Name = "John" },
        new Student { Id = "2", Name = "Jane" }
    };
            mockStudentService.Setup(s => s.GetStudents()).Returns(students);

            var controller = new StudentController(mockStudentService.Object,mockUserManager.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(students, result.Model);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
