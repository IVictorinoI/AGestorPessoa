using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Customers;
using Domain.Models.Debts;
using Domain.Models.Debts.Payments;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Customers;
using Repository.Debts;
using Repository.Users;

namespace Application.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<DebtPayment> DebtPayments { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfig().Configure(modelBuilder.Entity<User>());
            new CustomerConfig().Configure(modelBuilder.Entity<Customer>());
            new DebtConfig().Configure(modelBuilder.Entity<Debt>());
            new DebtPaymentConfig().Configure(modelBuilder.Entity<DebtPayment>());

        }
    }
}
