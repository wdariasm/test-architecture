using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using TicketManagement.Api.Services;
using TicketManagement.Api.Utility;
using TicketManagement.Application;
using TicketManagement.Application.Contracts;
using TicketManagement.Infrastructure;
using TicketManagement.Persistence;
using TicketManagement.Api.Middleware;

namespace TicketManagement.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            AddSwagger(services);

            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddPersistenceServices(Configuration);

            services.TryAddSingleton<ILoggedInUserService, LoggedInUserService>();

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder=> builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ticket Management API",

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
            });

            app.UseCustomExceptionHandler();

            app.UseCors("Open");
            app.UseEndpoints(endPoints => { endPoints.MapControllers(); });
        }
    }
}
