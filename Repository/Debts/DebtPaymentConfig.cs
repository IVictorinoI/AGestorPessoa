using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Debts.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Debts
{
    public class DebtPaymentConfig : IEntityTypeConfiguration<DebtPayment>
    {
        public void Configure(EntityTypeBuilder<DebtPayment> builder)
        {
            builder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            builder.ToTable("DebtPayment");
            builder.HasKey("Id");

            builder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);


            builder
                .Property(p => p.DebtId)
                .IsRequired();

            builder
                .Property(p => p.Date)
                .IsRequired();

            builder
                .Property(p => p.Value)
                .IsRequired();

            builder
                .Property(p => p.Status)
                .IsRequired();
            
        }
    }
}
