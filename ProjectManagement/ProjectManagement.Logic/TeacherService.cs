using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;

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
    }
}
