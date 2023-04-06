

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }
    }
}
