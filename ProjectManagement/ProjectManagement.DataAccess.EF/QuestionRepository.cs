

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }
    }
}
