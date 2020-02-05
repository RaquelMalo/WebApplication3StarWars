using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication3StarWars.Services.Factory;
using WebApplication3StarWars.Services.Register;
using WebApplication3StarWars.Services.Repository;
using WebApplication3StarWars.Services.Specification;
using WebApplication3StarWars.Services.Splitter;
using WebApplication3StarWars.Cross_Structure;

namespace WebApplication3StarWars
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<ISaveRepository, SaveRepository>();
            services.AddScoped<IRebelFactory, RebelFactory>();
            services.AddScoped<ISpecification, Validator>();
            services.AddScoped<ISplitter, Splitter>();
            services.AddSingleton<IRegister, Register>();
            if (Environment.IsDevelopment())
                services.AddScoped<IRepository, FakeRepository>();
            else
                services.AddScoped<IRepository, RebelRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            loggerFactory.AddFile("Logs/StarWars-{Date}.txt");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            //if (env.IsDevelopment())

            //    app.UseDeveloperExceptionPage();
            //else
            //    app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}