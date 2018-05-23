using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.ConfiguratonClasses
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);

            builder
                .Property(u => u.FirstName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(u => u.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(u => u.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(80);

            builder
                .Property(u => u.Password)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(25);
        }
    }
}
