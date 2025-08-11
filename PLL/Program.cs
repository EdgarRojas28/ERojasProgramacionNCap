using Microsoft.EntityFrameworkCore;

namespace PLL
{
    public class Program
    {
        static void Main(string[] args)
        {




            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var conString = builder.Configuration.GetConnectionString("ERojasProgramacionNCapas");
            builder.Services.AddDbContext<DL.ErojasProgramacionNcapasContext>(options => options.UseSqlServer(conString));

            var app = builder.Build();
            // Configure the HTTP request pipeline.


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }



    }
}
