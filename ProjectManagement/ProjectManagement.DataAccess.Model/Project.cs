

using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.DataAccess.Model
{
    public class Project
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }    
        public DateTime Deadline { get; set; }

        public Guid DisciplineId { get; set; }
        public Discipline Discipline { get; set; }  

        public ICollection<StudentProject>? StudentProjects { get; set; }

        public string TeacherId { get; set; }

        public User Teacher { get; set;}

     

    }
}
