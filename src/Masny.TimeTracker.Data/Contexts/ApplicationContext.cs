using Masny.TimeTracker.Data.Configurations;
using Masny.TimeTracker.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Masny.TimeTracker.Data.Contexts
{
    /// <summary>
    /// Main application context.
    /// </summary>
    public class ApplicationContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Contructor with params.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for Projects.
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// DbSet for Records.
        /// </summary>
        public DbSet<Record> Records { get; set; }

        /// <summary>
        /// DbSet for Goals.
        /// </summary>
        public DbSet<Goal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new RecordConfiguration());
            builder.ApplyConfiguration(new GoalConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
