﻿
namespace ProjectManagement.DataAccess.Model
{
    public class StudentDiscipline
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
