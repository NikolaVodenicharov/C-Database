using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Data.ConfigurationClasses
{
    public class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder
                .Property(v => v.Comment)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(250);

            builder
                .Property(v => v.Date)
                .IsRequired(true);

            builder
                .HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(v => v.PatientId);
        }
    }
}
