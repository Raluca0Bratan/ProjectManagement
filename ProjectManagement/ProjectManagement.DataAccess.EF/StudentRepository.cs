

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }
    }
}
