using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Customers
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            builder.ToTable("Customer");
            builder.HasKey("Id");

            builder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Property(p => p.BirthDate)
                .IsRequired();

            builder
                .Property(p => p.Address)
                .HasMaxLength(255);

            builder
                .Property(p => p.Occupation)
                .HasMaxLength(100);

            builder
                .Property(p => p.Salary)
                .IsRequired();

            builder
                .Property(p => p.Active)
                .IsRequired();
        }
    }
}
