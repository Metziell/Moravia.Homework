using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moravia.Homework;

using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices)
            .Build()
            .Services
            .GetRequiredService<Executor>()
            .Execute();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var serilogLogger = new LoggerConfiguration()
            .WriteTo.File("log.txt")
            .CreateLogger();
        services.AddLogging(builder => 
        {
            builder.ClearProviders();
            builder.AddSerilog(serilogLogger, true);
        });

        services.AddSingleton<Executor>();

        
    }
}