using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsteadBuyPlatform.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;

namespace InsteadBuyPlatform
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<InsteadBuyPlatformDbContext>(o => o.UseMySQL(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddSession();
            services
                .Configure<AppSetting>(Configuration.GetSection("AppSetting"))
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
         
            #region 跨域
            //var urls = Configuration["AppConfig:Cores"].Split(',');
            var urls = new string[] { "http://www.maidongxi.xyz/", "https://www.maidongxi.xyz/"};
            services.AddCors(options =>
            options.AddPolicy("AllowSameDomain",
                 builder => builder.WithOrigins(urls).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
             );

            #endregion

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutoFacModule>();
            containerBuilder.RegisterAssemblyTypes(this.GetType().GetTypeInfo().Assembly).PropertiesAutowired();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
