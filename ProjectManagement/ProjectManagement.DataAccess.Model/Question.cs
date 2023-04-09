

namespace ProjectManagement.DataAccess.Model
{
    public class Question:ModelEntity 
    {
        

        public string Text { get; set; }    

        public Guid StudentId { get; set; } 

        public Student Student { get; set;}

        public Guid DisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        public Guid AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
