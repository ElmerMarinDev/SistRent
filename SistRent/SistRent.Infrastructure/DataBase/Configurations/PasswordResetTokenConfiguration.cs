using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.DataBase.Configurations
{
    public class PasswordResetTokenConfiguration : IEntityTypeConfiguration<PasswordResetToken>
    {
        public void Configure(EntityTypeBuilder<PasswordResetToken> builder)
        {
            builder.ToTable("PasswordResetTokens");

            builder.HasKey(x => x.IdPasswordResetToken);

            builder.Property(x => x.TokenHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.PasswordResetTokens)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.TokenHash)
                .IsUnique();
        }
    }
}
