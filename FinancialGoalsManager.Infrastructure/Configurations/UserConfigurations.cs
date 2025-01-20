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
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).HasMaxLength(50)
                .HasColumnType("NVARCHAR")
                .IsRequired();

            builder.Property(x => x.Cpf).HasMaxLength(11)
                .IsRequired();
            builder.HasIndex(x => x.Cpf)
                .IsUnique();

            builder.Property(x => x.Email).HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasMany(x => x.FinancialGoals)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

        }
    }
}
