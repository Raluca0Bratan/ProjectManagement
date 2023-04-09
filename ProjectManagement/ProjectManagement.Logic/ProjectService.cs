using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;

namespace ProjectManagement.Logic
{
    public class ProjectService
    {
        private readonly IProjectRepository projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public IEnumerable<Project> GetProjects()
        {
            return projectRepository.GetAll();
        }

        public void AddProject(Project project)
        {
            projectRepository.Add(project);
            
        }

        public Project GetProjectById(Guid projectId)
        {
            var project = projectRepository.GetById(projectId);
            if (project != null)
            {
                return project;
            }
            else
            {
                throw new ArgumentException($"Project with id {projectId} does not exist.");
            }
        }

        public void UpdateProject(Project updatedProject)
        {
            projectRepository.Update(updatedProject);
        }

        public void RemoveProject(Guid projectId)
        {
            var project = projectRepository.GetById(projectId);
            if (project != null)
            {
                projectRepository.Remove(projectId);
                
            }
            else
            {
                throw new ArgumentException($"Project with id {projectId} does not exist.");
            }
        }
    }
}

