using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taste.DataAccess.Data;
using Taste.DataAccess.Data.Repository;
using Taste.DataAccess.Data.Repository.IRepository;

namespace Taste {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration=configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount=true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //dependency injection artik kullanilabilir. -->UnitOfWork ile ilgili.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //ASP.Net Core i�in iki t�r routing var. Endpoint routing ve Classic routing
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);// En son 3.0 vardi. Bende latest i kullandim
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            //services.AddRazorPages().AddRazorRuntimeCompilation(); //services.AddControllersWithViews().AddRazorRuntimeCompilation(); eklenince bu silindi.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseRouting(); //sildik.

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc();
            // Artik Endpoint routing kullanmayacagiz.
            //app.UseEndpoints(endpoints => {
            //    endpoints.MapRazorPages();
            //});
        }
    }
}
