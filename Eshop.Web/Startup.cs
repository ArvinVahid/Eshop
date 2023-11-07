using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Services.UserServices;
using Eshop.Data.AutoFac;
using Eshop.Data.Context;
using Eshop.Data.Repositories;
using Eshop.Data.UserServices;
using Eshop.Web.DTOs;
using Eshop.Web.ValueProvider;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Eshop.Web
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
            #region Configs

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Startup));

            services.AddRazorPages();

            services.AddMvc(options =>
            {
                options.ValueProviderFactories.Add(new FarsiQueryStringValueProviderFactory());
            });

            #endregion

            #region Elmah

            services.AddElmah<SqlErrorLog>(options =>
            {
                options.OnPermissionCheck = context => context.User.Identity.IsAuthenticated;
                options.ConnectionString = Configuration.GetConnectionString(nameof(EshopContext));
            });

            #endregion

            #region Database Context

            services.AddDbContext<EshopContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EshopContext"));
            });

            #endregion

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });

            #endregion

            #region Ioc

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductServices, ProductServices>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemServices, ItemServices>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderServices, OrderServices>();

            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailServices, OrderDetailService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryServices, CategoryServices>();

            services.AddScoped<ICategoryToProductRepository, CategoryToProductRepository>();
            services.AddScoped<ICategoryToProductServices, CategoryToProductServices>();

            #endregion
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RegisterModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseElmah();

            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                if (context.Request.Path.StartsWithSegments("/Admin"))
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.Redirect("/Login");
                    }
                    else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
                    {
                        context.Response.Redirect("/Login");
                    }
                }
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
