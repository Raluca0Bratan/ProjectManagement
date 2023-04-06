

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }
    }
}
