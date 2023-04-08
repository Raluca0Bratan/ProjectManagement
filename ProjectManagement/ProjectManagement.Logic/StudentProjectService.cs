using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System.Collections.Generic;

namespace ProjectManagement.Logic
{
    public class StudentProjectService
    {
        private readonly IStudentProjectRepository studentProjectRepository;
        public StudentProjectService(IStudentProjectRepository studentProjectRepository)
        {
            this.studentProjectRepository = studentProjectRepository;
        }

    }
}