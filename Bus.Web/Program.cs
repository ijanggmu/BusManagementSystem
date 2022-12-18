using Bus.Repo;
using Bus.Services;
using Bus.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//namespace Bus.Web
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}
var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection"))
                );
builder.Services.ConfigureApplicationServices();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IRouteService, RouteService>();
builder.Services.AddTransient<IBusdetailsService, BusDetailsService>();


////services.AddAuthentication("CookieAuth")
////    .AddCookie("CookieAuth", config =>
////    {
////        config.Cookie.Name = "Gradmas.Cookie";
////        config.LoginPath = "/BusDetails/Authenticate";
////    });
builder.Services.AddControllersWithViews();

//builder.Services.AddControllers();

//builder.Services.AddDbContext<ProductContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));

//});

//builder.Services.AddScoped<IProductService, ProductService>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
//who are you?
app.UseAuthentication();
//are you allowed?
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
