using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NurseryApp.Data;
using NurseryApp.Models;
using NurseryApp.Models.Handler;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.Services;

namespace NurseryApp
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:IdentityDefaultConnection"]));

            services.AddDbContext<NurseryDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Landscaper", policy => policy.Requirements.Add(new LandscaperRequirement()));
            });


            //services.AddDefaultIdentity<IdentityUser>()
                //.AddDefaultUI(UIFramework.Bootstrap4)
                //.AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
            })
            .AddGoogle(o =>
            {
                o.ClientId = Configuration["Authentication:Google:ClientId"];
                o.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                o.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                o.ClaimActions.Clear();
                o.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                o.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                o.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                o.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                o.ClaimActions.MapJsonKey("urn:google:profile", "link");
                o.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            }); 

            services.AddScoped<IAuthorizationHandler, LandscaperHandler>();

            services.AddScoped<IBasketProduct, BasketProductService>();
            services.AddScoped<IInventory, InventoryService>();
            services.AddScoped<IShop, ShopService>();
            services.AddScoped<IBasket, BasketService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
