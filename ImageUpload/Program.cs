using ImageUpload.Models;

namespace ImageUpload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(o => // Ajout des options pour pouvoirutiliser Json dans le projet
            {
                o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                o.JsonSerializerOptions.PropertyNamingPolicy = null;

            });
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            FileService fs = new FileService();
            fs.initBdd();

            app.UseEndpoints(endpoints => // Permet de redéfinir le routing
            {
                endpoints.MapControllerRoute(  //Ajout d'une route par défaut
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}
