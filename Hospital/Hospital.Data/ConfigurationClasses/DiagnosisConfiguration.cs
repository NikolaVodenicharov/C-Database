using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Data.ConfigurationClasses
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            builder
                .Property(d => d.Comment)
                .HasMaxLength(250)
                .IsRequired(false)
                .IsUnicode(true);                
        }
    }
}
