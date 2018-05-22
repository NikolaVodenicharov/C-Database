using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Data.ConfigurationClasses
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder
                .Property(d => d.Speciality)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);
        }
    }
}
