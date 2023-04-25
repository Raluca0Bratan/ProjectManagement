

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace ProjectManagement.DataAccess.EF
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly DbContext context; 
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public Student GetStudentById(Guid studentId)
        {
            var student = this.context.Set<Student>().FirstOrDefault(s=>s.StudentId == studentId);    
            return student;
        }
        
        public List<Disciplines> GetDisciplinesOfStudent (Guid studentId)
        {
            var student = GetStudentById(studentId);
            return student.Disciplines;
        }
        public List<Projects> GetProjectsOfStudentOfDiscipline(Guid studentId,Guid disciplineId)
        {
            var student = GetStudentById(studentId);
            var studentProjects = student.Projects;
            var studentProjectsOfDiscipline = studentProjects
                .Select(sp=>sp.Discipline.Id == disciplineId)
                .ToList();
            return studentProjectsOfDiscipline;
        }
        public List<Question> GetQuestionsOfDiscipline(Guid disciplineId)
        {
            var discipline = this.context.Set<Discipline>().First(d=>d.Id == disciplineId); 
            return discipline.Questions;    
        }
    }
}
