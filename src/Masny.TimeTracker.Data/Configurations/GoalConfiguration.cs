using Masny.TimeTracker.Data.Constants;
using Masny.TimeTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Masny.TimeTracker.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Goal entity.
    /// </summary>
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Goals, Schema.Tracker)
                .HasKey(goal => goal.Id);

            builder.Property(goal => goal.Id)
                .UseIdentityColumn();

            builder.Property(goal => goal.Title)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);

            builder.Property(goal => goal.Text)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthLong);

            builder.Property(goal => goal.End)
                .HasColumnType(SqlConfiguration.SqlSmallDateFormat);

            builder.HasOne(goal => goal.Project)
                .WithMany(project => project.Goals)
                .HasForeignKey(goal => goal.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
