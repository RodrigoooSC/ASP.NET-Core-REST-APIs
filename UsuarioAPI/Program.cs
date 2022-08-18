using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace UsuarioAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            // Realiza a configuração para resgatar em tempo de execução as secrets anteriormente configuradas no appsettings.json
            .ConfigureAppConfiguration((context, builder) =>
            builder.AddUserSecrets<Program>());
    }
}
