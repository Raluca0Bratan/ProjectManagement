using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;
using System.Linq.Expressions;

namespace ProjectManagement.Logic
{
    public class TeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public Teacher AddDisciplineToTeacher(string teacherId, Discipline disciplineToAdd)
        {
            return teacherRepository.AddDisciplineToTeacher(teacherId, disciplineToAdd);
        }


        public Discipline UpdateDiscipline(Discipline disciplineToUpdate)
        {
            return teacherRepository.UpdateDiscipline(disciplineToUpdate);
        }

        public void RemoveDisciplineFromTeacher(string teacherId, Discipline discipline)
        {
            teacherRepository.RemoveDisciplineFromTeacher(teacherId, discipline);
        }


        public List<Discipline> GetDisciplinesOfTeacher(string teacherId)
        {
            return teacherRepository.GetDisciplinesOfTeacher(teacherId);
        }


        public Discipline GetDisciplineById(Guid disciplineId)
        {
            return teacherRepository.GetDisciplineById(disciplineId);
        }


        public Project AddProject(Guid disciplineId, Project projectToAdd)
        {
            return teacherRepository.AddProject(disciplineId, projectToAdd);
        }


        public void RemoveProject(Guid disciplineId, Project projectToRemove)
        {
            teacherRepository.RemoveProject(disciplineId, projectToRemove);
        }


        public Project UpdateProject(Project projectToUpdate)
        {
            return teacherRepository.UpdateProject(projectToUpdate);
        }


        public Project GetProjectById(Guid projectId)
        {
            return teacherRepository.GetProjectById(projectId);
        }


        public List<Student> GetStudentsOfProject(Guid projectId)
        {
            return teacherRepository.GetStudentsOfProject(projectId);
        } 


        public List<Student> GetStudentsOfDiscipline(Guid disciplineId)
        {
            return teacherRepository.GetStudentsOfDiscipline(disciplineId);
        }


        public Answer GetAnswerOfQuestion(Guid questionId)
        {
            return teacherRepository.GetAnswerOfQuestion(questionId);
        }


        public IEnumerable<Project> GetProjectsOfDiscipline(Guid disciplineId)
        {
            return teacherRepository.GetProjectsOfDiscipline(disciplineId);
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            return teacherRepository.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            teacherRepository.Remove(teacher);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return teacherRepository.GetAll();
        }

        public Teacher Update(Teacher toUpdate)
        {
           return teacherRepository.Update(toUpdate);
        }

        public IQueryable<Teacher> FindByCondition(Expression<Func<Teacher, bool>> expression)
        {
            return teacherRepository.FindByCondition(expression);
        }

    }
}
