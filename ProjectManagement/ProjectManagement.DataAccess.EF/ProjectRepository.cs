
using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class ProjectRepository:BaseRepository<Project>, IProjectRepository
    {
        private readonly DbContext dbContext;
        public ProjectRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }   

        //public IEnumerable<Student> GetStudentsOfProject(Guid projectId)
        //{
        //    var project = GetById(projectId);
        //    var list = project.StudentProjects;
        //    return list;

        //    var listStudents = dbContext.Set<Project>()
        //        .Where(p=>p.Id==projectId)
        //        .Select(p=>p.StudentProjects)
        //        .ToList();
        //    return listStudents;
        //}
    }
}
