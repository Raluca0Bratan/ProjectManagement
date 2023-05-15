

namespace ProjectManagement.DataAccess.Model
{
    public class Discipline
    {
       
        public Guid Id { get; set; }    
        public string Name { get; set; }

        public string TeacherId { get; set; } 

        public User Teacher { get; set;}

        public ICollection<StudentDiscipline>? StudentDisciplines { get; set; }

        public ICollection<Project>? Projects { get; set; }

        public ICollection<Question>? Questions { get; set; }

    }
}
