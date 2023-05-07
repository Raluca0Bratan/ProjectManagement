

namespace ProjectManagement.DataAccess.Model
{
    public class StudentProject
    {
        public string StudentId { get; set; }
        public Guid ProjectId { get; set; }

        public Student Student { get; set; }

        public Project Project { get; set; }
    }
}
