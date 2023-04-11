
namespace ProjectManagement.DataAccess.Model
{
    public class Student : User
    {
        public ICollection<StudentDiscipline>? StudentDisciplines { get; set; }
        public ICollection<StudentProject>? StudentProjects { get; set; }

        public ICollection<Question>? Questions { get; set; }

    }
}
