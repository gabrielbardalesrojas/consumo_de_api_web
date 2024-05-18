using WorkerService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient(); // Agrega HttpClient

                    services.AddSingleton<CursoService>();

                    // Configura el servicio de correo electrónico con tus credenciales SMTP
                    services.AddSingleton(new EmailService("smtp.example.com", 587, "your-email@example.com", "your-email-password"));

                    services.AddHostedService<Worker>();
                });
    }
}

