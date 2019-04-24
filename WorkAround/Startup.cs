using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkAround.Data;

namespace WorkAround
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
            services.Configure<CookiePolicyOptions>(options =>
            {
          // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(opt=>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequiredLength = 4;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
                

            var what = services.BuildServiceProvider();
            var cont = what.GetRequiredService<ApplicationDbContext>();
            cont.Users.Add(new IdentityUser
            {
                Email = "what",
                
            });
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateUserRoles(serviceProvider).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Worker");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Worker"));
            }
        }
    }
}
