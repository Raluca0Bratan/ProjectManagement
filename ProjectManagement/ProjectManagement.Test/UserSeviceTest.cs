

using Microsoft.AspNetCore.Routing;
using Moq;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;

namespace ProjectManagement.Test
{
    [TestClass]
    public class UserServiceTest
    {

        [TestMethod]
        public void GetDisciplinesOfStudent_ReturnsDisciplines_WhenValidStudentId()
        {
            // Arrange
            string studentId = "456";
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var expectedDisciplines = new List<Discipline>
    {
        new Discipline { Id = Guid.NewGuid(), Name = "Math" },
        new Discipline { Id = Guid.NewGuid(), Name = "Science" }
    };
            userRepositoryMock.Setup(repo => repo.GetDisciplinesOfStudent(studentId)).Returns(expectedDisciplines);

            // Act
            var result = userService.GetDisciplinesOfStudent(studentId);

            // Assert
            Assert.AreEqual(expectedDisciplines, result);
            userRepositoryMock.Verify(repo => repo.GetDisciplinesOfStudent(studentId), Times.Once);
        }

        [TestMethod]
        public void AddProject_ReturnsAddedProject()
        {
            // Arrange
            Guid disciplineId = Guid.NewGuid();
            var projectToAdd = new Project { Id = Guid.NewGuid(), Name = "New Project" };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.AddProject(disciplineId, projectToAdd)).Returns(projectToAdd);
            var userService = new UserService(userRepositoryMock.Object);

            // Act
            var result = userService.AddProject(disciplineId, projectToAdd);

            // Assert
            Assert.AreEqual(projectToAdd, result);
        }

        [TestMethod]
        public void RemoveProject_SuccessfullyRemovesProject()
        {
            // Arrange
            Guid disciplineId = Guid.NewGuid();
            var projectToRemove = new Project { Id = Guid.NewGuid(), Name = "Project to Remove" };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.RemoveProject(disciplineId, projectToRemove));
            var userService = new UserService(userRepositoryMock.Object);

            // Act
            userService.RemoveProject(disciplineId, projectToRemove);

            // Assert
            userRepositoryMock.Verify(u => u.RemoveProject(disciplineId, projectToRemove), Times.Once);
        }

        [TestMethod]
        public void GetAnswerOfQuestion_ReturnsAnswer()
        {
            // Arrange
            Guid questionId = Guid.NewGuid();
            var expectedAnswer = new Answer { Id = Guid.NewGuid(), Text = "Answer to Question" };
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.GetAnswerOfQuestion(questionId)).Returns(expectedAnswer);
            var userService = new UserService(userRepositoryMock.Object);

            // Act
            var result = userService.GetAnswerOfQuestion(questionId);

            // Assert
            Assert.AreEqual(expectedAnswer, result);
        }
    }
}
