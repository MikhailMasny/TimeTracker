using Masny.TimeTracker.Data.Constants;
using Masny.TimeTracker.Data.Enums;
using Masny.TimeTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Masny.TimeTracker.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Project entity.
    /// </summary>
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Projects, Schema.Tracker)
                .HasKey(project => project.Id);

            builder.Property(project => project.Id)
                .UseIdentityColumn();

            builder.Property(project => project.Name)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);

            builder.Property(project => project.CreationTime)
                .HasColumnType(SqlConfiguration.SqlSmallDateFormat);

            builder.Property(project => project.Type)
                .HasConversion(new EnumToNumberConverter<ProjectType, int>());

            builder.HasOne(project => project.User)
                .WithMany(user => user.Projects)
                .HasForeignKey(project => project.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
