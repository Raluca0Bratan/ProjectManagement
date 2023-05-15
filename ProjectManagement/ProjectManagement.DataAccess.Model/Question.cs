

namespace ProjectManagement.DataAccess.Model
{
    public class Question
    {
        
        public Guid Id {  get; set; }   
        public string Text { get; set; }    

        public string StudentId { get; set; } 

        public User Student { get; set;}

        public Guid DisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        public Guid AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
