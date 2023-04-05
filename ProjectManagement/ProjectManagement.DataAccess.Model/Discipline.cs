

namespace ProjectManagement.DataAccess.Model
{
    public class Discipline:ModelEntity
    {
       
        public string Name { get; set; }

        public Guid TeacherId { get; set; } 

        public Teacher Teacher { get; set;}

        public List<StudentDiscipline> StudentDiscipline { get; set; }

        public List<Project> Projects { get; set; }

    }
}
