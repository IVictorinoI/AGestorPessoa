using Domain.Models.Customers;
using Domain.Models.Debts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Debts
{
    public class DebtConfig : IEntityTypeConfiguration<Debt>
    {
        public void Configure(EntityTypeBuilder<Debt> builder)
        {
            builder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            builder.ToTable("Debt");
            builder.HasKey("Id");

            builder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            builder
                .Property(p => p.CustomerId)
                .IsRequired();

            builder
                .Property(p => p.Title)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.DueDate)
                .IsRequired();

            builder
                .Property(p => p.Value)
                .IsRequired();

            builder
                .Property(p => p.PayValue)
                .IsRequired();

            builder
                .Property(p => p.RemainingValue)
                .IsRequired();
            
            builder
                .Property(p => p.PaidLate)
                .IsRequired();

            builder
                .Property(p => p.Status)
                .IsRequired();

            builder
                .HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomerId);

        }
    }
}
