using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Hospital.Data.ConfigurationClasses
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.FirstName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(p => p.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(p => p.Address)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(250);

            builder
                .Property(p => p.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(80);
        }
    }
}
