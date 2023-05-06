namespace ProjectManagement.DataAccess.Model
{
    public class Answer
    {
        public Guid Id { get; set; }    
        public string Text { get; set; }    

        public string TeacherId { get; set; } 

        public Teacher Teacher { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
