﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    private const string UserOrganizationsTableName = "UserOrganizations";
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Names)
            .HasMaxLength(50);
        
        builder.Property(x => x.Lastnames)
            .HasMaxLength(50);
        
        builder.Property(x => x.Email)
            .HasMaxLength(255);
        
        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.AccountNumber)
            .IsUnique()
            .HasFilter("\"AccountNumber\" IS NOT NULL");
        
        builder.HasIndex(x => x.EmailConfirmationToken)
            .IsUnique()
            .HasFilter("\"EmailConfirmationToken\" IS NOT NULL");
        
        builder.HasIndex(x => x.ResetPasswordToken)
            .IsUnique() 
            .HasFilter("\"ResetPasswordToken\" IS NOT NULL");
        
        builder.HasOne(x => x.Career)
            .WithMany(c => c.Users)
            .HasForeignKey(x => x.CareerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Organizations)
            .WithMany(o => o.Users)
            .UsingEntity(j => j.ToTable(UserOrganizationsTableName));
    }
}