using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using TeamTool.Mappings;
using TeamTool.Models;
using TeamTool.Models.Interfaces;
using TeamTool.Models.Repositories;

namespace TeamTool
{

    /// <summary>
    ///     Startup is a built-in dependency injection container used to add services in the application. 
    ///     Configures the request pipeline that handles all requests made to the application
    ///     NB: configure self-signed certificate for development purposes: https://support.microsoft.com/en-us/help/3180222/warnings-about-an-untrusted-certificate-after-you-install-visual-studio-2015-update-3 
    ///     Script: https://gist.github.com/camieleggermont/5b2971a96e80a658863106b21c479988
    /// </summary>
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment env)
        {
            Environment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        /// <summary>
        ///     This method gets called by the runtime before configure to add services to the container.
        /// </summary>
        /// <param name="services"> Service collection to contain dependencies. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddScoped<IContext, TeamContext>();
            services.AddDbContext<TeamContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ITeamRepository,TeamRepository>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            // Add MVC framework services.
            services.AddLogging();
            services.AddMvc();

            services.Configure<MvcOptions>(options => // Require SSL for safe encrypted data transfer 
            {
                if (Environment.IsProduction()) // Setup HTTPS to receive client requests 
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                }
            });

            // Enable default camel case JSON data
            services.Configure<MvcJsonOptions>(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper();
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        ///     This allows the below serviced to be injected where used throughout the application
        ///     Dependency injection used to setup container for different services required by APP
        /// </summary>
        /// <param name="app"> Configure app request pipeline. </param>
        /// <param name="env"> Provide information about hosting environment. </param>
        /// <param name="loggerFactory"> Represents type used to configure logging system. </param>
        /// <param name="context"> Database context used to represent data model. </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IContext context)
        {
            // Configure mapping profiles  
            Mapper.Initialize(config =>
            {
                config.AddProfile<TeamProfile>();
                config.AddProfile<ProjectProfile>();
                config.AddProfile<MemberProfile>();
            });

            // Configure logging 
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Redirect all HTTP requests to HTTPS for safe communication
            var options = new RewriteOptions().AddRedirectToHttps(); 
            app.UseRewriter(options);

            // Configure environment 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            DbInitializer.Initialize(context); 

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
