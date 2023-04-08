using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System.Collections.Generic;

namespace ProjectManagement.Logic
{
    public class StudentDisiciplineService
    {
        private readonly IStudentDisiciplineRepository studentDisiciplineRepository;
        public StudentDisiciplineService(IStudentRepository studentDisiciplineRepository)
        {
            this.studentDisiciplineRepository = studentDisiciplineRepository;
        }

        public IEnumerable<StudentDisicipline> GetStudentDisiciplines()
        {
            return studentDisiciplineRepository.GetAll();
        }

    }
}