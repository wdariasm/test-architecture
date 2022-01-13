using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Models.Authentication;
using TicketManagement.Identity.Models;
using TicketManagement.Identity.Services;

namespace TicketManagement.Identity
{
    public static class IdentityServiceRegistration
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<TicketIdentityDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("TicketIdentity"),
                b => b.MigrationsAssembly(typeof(TicketIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TicketIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
