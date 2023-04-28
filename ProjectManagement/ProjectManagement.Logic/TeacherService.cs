using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Logic
{
    public class TeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return teacherRepository.GetAll();
        }

        public void AddTeacher(Teacher teacher)
        {
            teacherRepository.Add(teacher);
            
        }

        public Teacher GetTeacherById(Guid teacherId)
        {
            var teacher = teacherRepository.GetById(teacherId);
            if (teacher != null)
            {
                return teacher;
            }
            else
            {
                throw new ArgumentException($"Teacher with id {teacherId} does not exist.");
            }
        }

        public void UpdateTeacher(Teacher updatedTeacher)
        {
            teacherRepository.Update(updatedTeacher);   
        }

        public void RemoveTeacher(Guid teacherId)
        {
            var teacher = teacherRepository.GetById(teacherId);
            if (teacher != null)
            {
                teacherRepository.Remove(teacherId);
            }
            else
            {
                throw new ArgumentException($"Teacher with id {teacherId} does not exist.");
            }
        }
        public Teacher AddDisciplineToTeacher(Guid teacherId, Discipline disciplineToAdd)
        {
           return teacherRepository.AddDisciplineToTeacher(teacherId, disciplineToAdd);
        }

        public Discipline UpdateDiscipline(Discipline disciplineToUpdate)
        {
           return teacherRepository.UpdateDiscipline(disciplineToUpdate);
        }
        public void RemoveDisciplineFromTeacher(Guid teacherId, Discipline discipline)
        {
           teacherRepository.RemoveDisciplineFromTeacher(teacherId, discipline);
        }

        public List<Discipline> GetDisciplinesOfTeacher(Guid teacherId)
        {
          return  teacherRepository.GetDisciplinesOfTeacher(teacherId);
        }

        public Discipline GetDisciplineById(Guid disciplineId)
        {
           return teacherRepository.GetDisciplineById(disciplineId);
        }

        public Project AddProject(Guid disciplineId, Project projectToAdd)
        {
          return  teacherRepository.AddProject(disciplineId, projectToAdd);
        }

        public void RemoveProject(Guid disciplineId, Project projectToRemove)
        {
            teacherRepository.Remove(disciplineId);
        }

        public Project UpdateProject(Project projectToUpdate)
        {
          return  teacherRepository.UpdateProject(projectToUpdate);
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
          return  teacherRepository.GetAnswerOfQuestion(questionId);
        }

        public IEnumerable<Project> GetProjectsOfDiscipline(Guid disciplineId)
        {
           return teacherRepository.GetProjectsOfDiscipline(disciplineId);

        }
    }
}
