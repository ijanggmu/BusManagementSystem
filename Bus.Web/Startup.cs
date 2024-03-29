//using Bus.Repo;
//using Bus.Services;
//using Bus.Services.Contracts;
//using MediatR;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System.Reflection;

//namespace Bus.Web
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddDbContext<ApplicationDbContext>(
//                options => options.UseSqlServer(
//                    Configuration.GetConnectionString("DefaultConnection"))
//                );
//            services.ConfigureApplicationServices();
//            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//            services.AddTransient<IRouteService, RouteService>();
//            services.AddTransient<IBusdetailsService, BusDetailsService>();


//            ////services.AddAuthentication("CookieAuth")
//            ////    .AddCookie("CookieAuth", config =>
//            ////    {
//            ////        config.Cookie.Name = "Gradmas.Cookie";
//            ////        config.LoginPath = "/BusDetails/Authenticate";
//            ////    });
//            services.AddControllersWithViews();

//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }
//            app.UseHttpsRedirection();

//            app.UseStaticFiles();

//            app.UseRouting();

//            //who are you?
//            app.UseAuthentication();

//            //are you allowed?
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//            });
//        }
//    }
//}
