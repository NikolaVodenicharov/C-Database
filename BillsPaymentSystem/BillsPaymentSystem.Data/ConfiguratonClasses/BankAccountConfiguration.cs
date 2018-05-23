using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.ConfiguratonClasses
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasKey(b => b.BankAccountId);

            builder
                .Property(b => b.BankName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(b => b.SwiftCode)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(20);

            builder
                .Property(b => b.Balance)
                .HasDefaultValue(0.0M);
        }
    }
}
