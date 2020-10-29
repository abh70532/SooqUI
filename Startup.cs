using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WrokFlowWeb.Areas.Identity.Data;
using WrokFlowWeb.Controllers;
using WrokFlowWeb.Database;
using WrokFlowWeb.Data;
using WrokFlowWeb.Services;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.Areas.Identity.Pages.Account;

namespace WrokFlowWeb
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

            services.AddDbContext<WrokFlowWebEntityContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("WrokFlowWebContextConnection")));

            services.AddControllersWithViews();
            services.AddRazorPages();




            //services.AddDefaultIdentity<WrokFlowWebUser,IdentityRole>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.Password.RequiredLength = 6;
            //})



            services.AddDefaultIdentity<WrokFlowWebUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<WrokFlowWebContext>();
                //.AddDefaultTokenProviders();

            //services.AddScoped<RoleController, RoleManager>();
            services.AddMvc(options=> {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                options.Filters.Add(new AuthorizeFilter());
            });
            
            services.AddScoped<ISupplierRequestService, SupplierRequestService>();
            services.AddScoped<ICategoryMasterService, SupplierRequestService>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<ISupplierRegistrationService, SupplierRegistrationService>();
            

            services.AddScoped<UnitOfWork.IUnitOfWork, WrokFlowWeb.UnitOfWork.UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
