using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpochApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace EpochApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<Repositories.AccountRepository>();

            services.AddDbContextPool<DbContexts.AccountDbContext>( // replace "YourDbContext" with the class name of your DbContext
                options => options.UseMySql(Configuration["ConnectionStrings:AccountServer"], // replace with your Connection String
                mysqlOptions =>
                {
                    mysqlOptions.ServerVersion(new Version(5, 7), ServerType.MySql); // replace with your Server Version and Type
                    mysqlOptions.DisableBackslashEscaping();
                }
            ));

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegistrationValidator>());

            services.AddCors();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable CORS with CORS Middleware
            // See: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.1#enable-cors-with-cors-middleware
            //app.UseCors(builder => builder.WithOrigins("http://example.com"));

            app.UseMvc();
        }
    }
}
