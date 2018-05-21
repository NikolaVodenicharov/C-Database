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
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(250);
        }
    }
}
