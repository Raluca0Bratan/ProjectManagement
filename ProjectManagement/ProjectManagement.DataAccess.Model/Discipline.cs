

namespace ProjectManagement.DataAccess.Model
{
    public class Discipline:ModelEntity
    {
       
        public string Name { get; set; }

        public Guid TeacherId { get; set; } 

        public Teacher Teacher { get; set;}

        public ICollection<StudentDiscipline> StudentDisciplines { get; set; }

        public ICollection<Project> Projects { get; set; }

    }
}
