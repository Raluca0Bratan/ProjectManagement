

namespace ProjectManagement.DataAccess.Model
{
    public class Project:ModelEntity
    {
       
        public string Name { get; set; }    
        public DateTime Deadline { get; set; }

        public Guid DisciplineId { get; set; }
        public Discipline Discipline { get; set; }  

        public List<StudentProject> StudentProjects { get; set; }

        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set;}

        public List<Question > Questions { get; set; }  

    }
}
