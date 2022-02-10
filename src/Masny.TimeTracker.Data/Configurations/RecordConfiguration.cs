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
    /// EF Configuration for Record entity.
    /// </summary>
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Records, Schema.Tracker)
                .HasKey(record => record.Id);

            builder.Property(record => record.Id)
                .UseIdentityColumn();

            builder.Property(record => record.Start)
                .HasColumnType(SqlConfiguration.SqlDateTimeFormat);

            builder.Property(record => record.End)
                .HasColumnType(SqlConfiguration.SqlDateTimeFormat);

            builder.Property(record => record.Type)
                .HasConversion(new EnumToNumberConverter<RecordType, int>());

            builder.HasOne(record => record.Project)
                .WithMany(project => project.Records)
                .HasForeignKey(record => record.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
