using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;

namespace RestoStock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<RestoStockContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Supermarket"))

            );

            //Manejo de las Cookies
            builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "MyCookieAuth";
                options.LoginPath = "/Account/Login";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
