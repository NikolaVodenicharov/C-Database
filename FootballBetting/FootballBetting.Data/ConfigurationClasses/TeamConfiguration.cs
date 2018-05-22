using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBetting.Data.ConfigurationClasses
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasKey(t => t.TeamId);

            builder
                .Property(t => t.Name)
                .IsRequired(true)
                .HasMaxLength(80);

            builder
                .Property(t => t.Initials)
                .IsRequired(true)
                .HasColumnType("NCHAR(3)");

            builder
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.TeamsPrimaryKitColor)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.TeamsSecondaryKitColor)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Town)
                .WithMany(to => to.Teams)
                .HasForeignKey(t => t.TownId);
        }
    }
}
