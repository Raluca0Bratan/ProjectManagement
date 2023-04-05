

namespace ProjectManagement.DataAccess.Model
{
    public class Question:ModelEntity 
    {
        

        public string Text { get; set; }    

        public Guid StudentId { get; set; } 

        public Student Student { get; set;}

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public Answer Answer { get; set; }
    }
}
