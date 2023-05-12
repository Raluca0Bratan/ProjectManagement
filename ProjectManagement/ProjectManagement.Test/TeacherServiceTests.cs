using Moq;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.EF;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Test
{
    public class TeacherServiceTests
    {
        private Mock<ITeacherRepository> mockRepository = new Mock<ITeacherRepository> ();
        private TeacherService teacherService;

        [TestInitialize]
        public void Setup()
        {
            // Create a Mock of ITeacherRepository
            mockRepository = new Mock<ITeacherRepository>();
            teacherService = new TeacherService(mockRepository.Object);
        }

        [TestMethod]
        public void GetProjectById_ShouldReturnCorrectProject()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var expectedProject = new Project { Id = projectId };
            mockRepository.Setup(tr => tr.GetProjectById(projectId)).Returns(expectedProject);

            // Act
            var result = teacherService.GetProjectById(projectId);

            // Assert
            Assert.AreEqual(expectedProject, result);
        }
    }
}

