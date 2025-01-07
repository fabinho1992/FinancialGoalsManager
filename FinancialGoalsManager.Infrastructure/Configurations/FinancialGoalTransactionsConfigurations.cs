using FinancialGoalsManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FinancialGoalsManager.Infrastructure.Configurations
{
    internal class FinancialGoalTransactionsConfigurations : IEntityTypeConfiguration<FinancialGoalTransactions>
    {
        public void Configure(EntityTypeBuilder<FinancialGoalTransactions> builder)
        {
            

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.TransactionDate)
                .IsRequired();

            builder.Property(x => x.TransactionType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.FinancialGoalId)
                .IsRequired();

        }
    }
}
