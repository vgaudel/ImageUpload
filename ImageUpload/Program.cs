namespace ImageUpload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                o.JsonSerializerOptions.PropertyNamingPolicy = null;

            });
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => // Permet de redéfinir le routing
            {
                endpoints.MapControllerRoute(  //Ajout d'une route par d�faut
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}
