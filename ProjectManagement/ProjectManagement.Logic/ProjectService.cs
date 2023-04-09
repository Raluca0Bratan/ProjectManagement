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
            projectRepository.SaveChanges();
        }

        public Project GetProjectById(int projectId)
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
            var project = projectRepository.GetById(updatedProject.Id);
            if (project != null)
            {
                project.Title = updatedProject.Title;
                project.Description = updatedProject.Description;
                projectRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Project with id {updatedProject.Id} does not exist.");
            }
        }

        public void RemoveProject(int projectId)
        {
            var project = projectRepository.GetById(projectId);
            if (project != null)
            {
                projectRepository.Remove(project);
                projectRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Project with id {projectId} does not exist.");
            }
        }
    }
}

