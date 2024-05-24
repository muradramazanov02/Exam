using Exam_Murad.Business.Service.Abstract;
using Exam_Murad.Business.Service.Concrets;
using Exam_Murad.Core.Abstract;
using Exam_Murad.Data.DAL;
using Exam_Murad.Data.RepositoryAbstract;
using Microsoft.EntityFrameworkCore;

namespace Exam_Murad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => 
            {
                opt.UseSqlServer("Server=CA-R215-PC13\\SQLEXPRESS;Database=Exam_MurasDB;Trusted_Connection=true;Integrated Security=true;TrustServerCertificate=true");
            });

            builder.Services.AddScoped<IAnimalService, AnimalService>();
            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
