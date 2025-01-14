using FinancialGoalsManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Infrastructure.Configurations
{
    public class FinancialGoalConfigurations : IEntityTypeConfiguration<FinancialGoal>
    {
        public void Configure(EntityTypeBuilder<FinancialGoal> builder)
        {
            

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50)
                .HasColumnType("NVARCHAR")
                .IsRequired();

            builder.Property(x => x.GoalAmount)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.Deadline)
                .IsRequired();

            builder.Property(x => x.IdealMonthlySaving)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.SelectedMonths)
                .IsRequired();

            builder.Property(x => x.SavedValue)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.HasMany(x => x.FinancialGoalTransactions)
                .WithOne(x => x.FinancialGoal)
                .HasForeignKey(x => x.FinancialGoalId);
        }
    }
}
