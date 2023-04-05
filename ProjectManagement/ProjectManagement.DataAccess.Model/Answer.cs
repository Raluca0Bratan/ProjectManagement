

namespace ProjectManagement.DataAccess.Model
{
    public class Answer:ModelEntity
    {
        
        public string Text { get; set; }    

        public Guid TeacherId { get; set; } 

        public Teacher Teacher { get; set; }

        public Question Question { get; set; }
    }
}
