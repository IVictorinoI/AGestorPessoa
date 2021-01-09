using System;
using System.Collections.Generic;
using System.Text;
using Application.Customers;
using Application.Customers.Mapper;
using Application.Customers.Validators;
using Application.Debts;
using Application.Debts.Mapper;
using Application.Debts.Payments;
using Application.Debts.Payments.Mapper;
using Application.Debts.Payments.Validators;
using Application.Debts.Validators;
using Application.Login;
using Application.Users;
using Application.Users.Current;
using Application.Users.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config
{
    public static class DependencyInjectorConfig
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAplicUser, AplicUser>();
            services.AddScoped<IAplicLogin, AplicLogin>();
            services.AddScoped<IUserValidator, UserValidator>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            
            services.AddScoped<IAplicCustomer, AplicCustomer>();
            services.AddScoped<ICustomerMapper, CustomerMapper>();
            services.AddScoped<ICustomerValidator, CustomerValidator>();

            services.AddScoped<IAplicDebt, AplicDebt>();
            services.AddScoped<IDebtMapper, DebtMapper>();
            services.AddScoped<IDebtValidator, DebtValidator>();

            services.AddScoped<IAplicDebtPayment, AplicDebtPayment>();
            services.AddScoped<IDebtPaymentMapper, DebtPaymentMapper>();
            services.AddScoped<IDebtPaymentValidator, DebtPaymentValidator>();
            

            return services;
        }
    }
}
