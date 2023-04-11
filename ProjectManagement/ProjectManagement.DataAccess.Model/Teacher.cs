

namespace ProjectManagement.DataAccess.Model
{
    public class Teacher : User
    {
        ICollection<Discipline>? Disciplines { get; set ; }
        ICollection<Project>? Projects { get; set ; }

        ICollection<Answer>? Answers { get; set ; }


    }
}
