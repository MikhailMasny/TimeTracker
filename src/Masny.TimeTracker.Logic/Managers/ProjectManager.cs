using Masny.TimeTracker.Data.Enums;
using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Logic.Managers
{
    /// <inheritdoc cref="IUserManager"/>
    public class ProjectManager : IProjectManager
    {
        private readonly IRepositoryManager<Project> _projectRepository;

        public ProjectManager(IRepositoryManager<Project> projectRepository)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task CreateAsync(ProjectDto model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException($"'{nameof(model.Name)}' cannot be null or empty.", nameof(model.Name));
            }

            var project = new Project
            {
                UserId = model.UserId,
                Name = model.Name,
                CreationTime = DateTime.Now,
                Type = ProjectType.Active,
                IsFavourite = model.IsFavourite,
            };

            await _projectRepository.CreateAsync(project);
            await _projectRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var project = await _projectRepository.GetEntityAsync(p => p.Id == id && p.UserId == userId);

            if (project is null)
            {
                throw new ArgumentException($"'{nameof(id)}' project not found.", nameof(id));
            }

            _projectRepository.Delete(project);
            await _projectRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(string userId)
        {
            var projects = await _projectRepository.GetAll()
                .Where(p => p.UserId == userId)
                .ToListAsync();

            if (!projects.Any())
            {
                return new List<ProjectDto>();
            }

            var projectDtos = new List<ProjectDto>();
            foreach (var project in projects)
            {
                projectDtos.Add(new ProjectDto
                {
                    Id = project.Id,
                    UserId = project.UserId,
                    Name = project.Name,
                    CreationTime = project.CreationTime,
                    Type = project.Type,
                    IsFavourite = project.IsFavourite,
                });
            }

            return projectDtos;
        }

        public async Task UpdateAsync(ProjectDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var project = await _projectRepository.GetEntityAsync(p => p.Id == model.Id && p.UserId == model.UserId);

            if (project is null)
            {
                throw new ArgumentException($"'{nameof(model.Id)}' project not found.", nameof(model.Id));
            }

            const string defaultSwaggerStringTypeValue = "string";
            if (project.Name != model.Name && model.Name != defaultSwaggerStringTypeValue)
            {
                project.Name = model.Name;
            }

            if (project.Type != model.Type && model.Type != ProjectType.Unknown)
            {
                project.Type = model.Type;
            }

            if (project.IsFavourite != model.IsFavourite)
            {
                project.IsFavourite = model.IsFavourite;
            }

            await _projectRepository.SaveChangesAsync();
        }
    }
}
