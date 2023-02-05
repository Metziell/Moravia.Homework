using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moravia.Homework;
using Moravia.Homework.Domain.Deserializer;
using Moravia.Homework.Domain.Interfaces;
using Moravia.Homework.Infrastructure;
using Moravia.Homework.Services;

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

        services.AddSingleton<IFileLoaderFactory, FileLoaderFactory>();
        services.AddSingleton<IFileSaverFactory, FileSaverFactory>();
        services.AddSingleton<IDeserializerFactory, DeserializerFactory>();

        services.AddScoped<IDeserializerService, DeserializerService>();
    }
}