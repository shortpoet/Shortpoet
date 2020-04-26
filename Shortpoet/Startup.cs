using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Shortpoet.Data;
using Shortpoet.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using Newtonsoft.Json;

namespace Shortpoet
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<ResumeDbContext>(options =>
                    options
                        .UseSqlServer(
                            Configuration.GetConnectionString("DefaultConnectionTest"))
                        .EnableSensitiveDataLogging()
                        );

            }
            else if (Environment.IsStaging()) 
            {
                services.AddDbContext<ResumeDbContext>(options =>
                    options
                        .UseSqlServer(
                            Configuration.GetConnectionString("DefaultConnectionTest"))
                        .EnableSensitiveDataLogging()
                        );    
            } 
            else if (Environment.IsProduction())
            {
            services.AddDbContext<ResumeDbContext>(options =>
                options
                    .UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    );
            }

            // services.AddDbContext<ResumeDbContext>(options =>
            //     options
            //         .UseSqlServer(
            //             Configuration.GetConnectionString("DefaultConnectionTest"))
            //         .EnableSensitiveDataLogging()
            //         );

            // services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //     .AddEntityFrameworkStores<ApplicationDbContext>();

            // services.AddIdentityServer()
            //     .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            // services.AddAuthentication()
            //     .AddIdentityServerJwt();

            // use below with option to enable UseMvc
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            }).AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            
            services.AddControllersWithViews();
            services.AddRazorPages();

            // services.AddHttpsRedirection(options =>
            // {
            //     // options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //     options.HttpsPort = 5001;
            // });
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                //configuration.RootPath = "ClientApp/build";
                configuration.RootPath = "VueClient/dist";
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://www.shortpoet.com",
                                            "http://www.shortpoet.com",
                                            "http://shortpoet.github.io",
                                            "https://shortpoet.github.io"
                                            );
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSpaStaticFiles();

            app.UseRouting();

            // app.UseAuthentication();
            // app.UseIdentityServer();
            // app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    // pattern: "api/{area:exists}/{controller}/{action=Index}/{id?}");
                    pattern: "api/{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                // endpoints.MapFallbackToFile("VueClient/dist/index.html");

                // if (env.IsDevelopment())
                // {
                //     endpoints.MapToVueCliProxy("{*path}", new SpaOptions { SourcePath = "VueClient" }, "serve", regex: "running at");
                // }
                // else
                // {
                //     endpoints.MapFallbackToFile("VueClient/dist/index.html");
                // }

            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                //spa.Options.SourcePath = "ClientApp";
                spa.Options.SourcePath = "VueClient";

                if (env.IsDevelopment())
                {
                    //spa.UseReactDevelopmentServer(npmScript: "start");
                    spa.UseVueCli(npmScript: "serve");
                    // spa.UseVueCli(npmScript: "servelocal");
                    // spa.UseVueCli(npmScript: "serve", port: 8080);
                }
            });
        }
    }
}
