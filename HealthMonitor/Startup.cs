using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HealthMonitor.Entity;
using HealthMonitor.DAC;
using HealthMonitor.Repo;
using Microsoft.Extensions.Logging;
using HealthMonitor.Common.CustomErrorLogger;
using Microsoft.AspNetCore.Identity;

namespace HealthMonitor
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
            var connection = @"Data Source=ADMIN-PC;Initial Catalog=AngularASPCoreDemo;Integrated Security=True";

            services.AddIdentity<UserCredential, IdentityRole>()
                    .AddEntityFrameworkStores<UserContext>();

            services.AddMvc();
            services.AddDataProtection();
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IDataProvider, DataProvider>();
            services.AddTransient<IUserRepoMongo, UserRepoMongo>();
            services.AddTransient<IUserRepoEF, UserRepoEF>();
            services.AddTransient<IMongoConfig, MongoConfig>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            var connection = @"Data Source=ADMIN-PC;Initial Catalog=AngularASPCoreDemo;Integrated Security=True";

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddContext(LogLevel.Information, connection);

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
