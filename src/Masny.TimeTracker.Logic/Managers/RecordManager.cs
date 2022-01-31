using Masny.TimeTracker.Data.Enums;
using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.Logic.Exceptions;
using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Logic.Managers
{
    /// <inheritdoc cref="IRecordManager"/>
    public class RecordManager : IRecordManager
    {
        private readonly IRepositoryManager<Record> _recordRepository;
        private readonly IRepositoryManager<Project> _projectRepository;

        public RecordManager(
            IRepositoryManager<Record> recordRepository,
            IRepositoryManager<Project> projectRepository)
        {
            _recordRepository = recordRepository ?? throw new ArgumentNullException(nameof(recordRepository));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task CreateAsync(RecordDto model, string userId)
        {
            if (model.Start >= model.End)
            {
                throw new AppException($"'{nameof(model.Start)}' >= '{nameof(model.End)}'.");
            }

            if (model.ProjectId == 0)
            {
                throw new AppException($"'{nameof(model.ProjectId)}' cannot be zero identifier.", nameof(model.ProjectId));
            }

            var isUserProjectExist = await _projectRepository
                .GetAll()
                .AnyAsync(p => p.Id == model.ProjectId && p.UserId == userId);

            if (!isUserProjectExist)
            {
                throw new AppException($"'{nameof(model.ProjectId)}' forbidden.", nameof(model.ProjectId));
            }

            var record = new Record
            {
                Start = model.Start,
                End = model.End,
                ProjectId = model.ProjectId,
                Type = RecordType.Classic
            };

            await _recordRepository.CreateAsync(record);
            await _recordRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var record = await _recordRepository
                .GetAll()
                .Include(r => r.Project)
                .SingleOrDefaultAsync(r => r.Id == id && r.Project.UserId == userId);

            if (record is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _recordRepository.Delete(record);
            await _recordRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecordDto>> GetAllByProjectIdAsync(int projectId, string userId)
        {
            var records = await _recordRepository
                .GetAll()
                .Include(r => r.Project)
                .Where(r => r.ProjectId == projectId && r.Project.UserId == userId)
                .ToListAsync();

            if (!records.Any())
            {
                return new List<RecordDto>();
            }

            var models = new List<RecordDto>();
            foreach (var record in records)
            {
                models.Add(new RecordDto
                {
                    Id = record.Id,
                    ProjectId = record.ProjectId,
                    Start = record.Start,
                    End = record.End,
                    Type = record.Type,
                });
            }

            return models;
        }

        public async Task UpdateAsync(RecordDto model, string userId)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var record = await _recordRepository
                .GetAll()
                .Include(r => r.Project)
                .SingleOrDefaultAsync(r => r.Id == model.Id && r.Project.UserId == userId);

            if (record is null)
            {
                throw new NotFoundException($"'{nameof(model.Id)}' record not found.", nameof(model.Id));
            }

            if (model.Start >= model.End)
            {
                throw new AppException($"'{nameof(model.Start)}' >= '{nameof(model.End)}'.");
            }

            if (record.Start != model.Start)
            {
                record.Start = model.Start;
            }

            if (record.End != model.End)
            {
                record.End = model.End;
            }

            await _recordRepository.SaveChangesAsync();
        }
    }
}
