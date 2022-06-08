using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateConsoleApp.ArgParser;
using TemplateConsoleApp.Helpers;
using TemplateConsoleApp.Models.Settings;
using TemplateConsoleApp.Services.Implementations;
using TemplateConsoleApp.Services.Interfaces;

namespace TemplateConsoleApp;

public class App
{
    private readonly ArgsOptions _parsedArgs;
    private readonly AppSettings _appSettings;
    private readonly IService1 _service1;
    private readonly IService2 _service2;

    public static GlobalSettings? GlobalSettings { get; set; }

    private App(IHost host, ArgsOptions parsedArgs)
    {
        if (host is null)
        {
            throw new ArgumentNullException(nameof(host));
        }

        GlobalSettings = host.Services.GetService<GlobalSettings>();
        _parsedArgs = parsedArgs ?? throw new ArgumentNullException(nameof(parsedArgs));
        _appSettings = host.Services.GetService<IOptions<AppSettings>>().Value;
        _service1 = host.Services.GetService<IService1>();
        _service2 = host.Services.GetService<IService2>();
    }

    public static App Configure(ArgsOptions parsedArgs)
    {
        string appSettingsFile = "appsettings.json";
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettingsFile, optional: false, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        configuration.Bind(appSettingsFile);

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddOptions<AppSettings>().Bind(configuration);
                services.AddSingleton<GlobalSettings>();
                services.AddSingleton<IService1, Service1>();
                services.AddSingleton<IService2, Service2>();
            })
            .Build();

        return new App(host, parsedArgs);
    }

    /// <summary>
    /// This is the main app method. Write your logic here.
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        PrettyConsole.WriteWrappedHeader("Hello world!");
        Exit(isSucces: true);
    }

    private static void Exit(bool isSucces = true, string? errorMessage = null)
    {
        if (isSucces)
        {
            PrettyConsole.WriteWrappedHeader("All completed. Quitting the application ...", headerColor: ConsoleColor.Green);

            CloseConsole(0);
        }

        PrettyConsole.WriteWrappedHeader(
            $"Somenthing went wrong. Quitting the application ... " +
            (string.IsNullOrEmpty(errorMessage) ? string.Empty : "\nError message: " + errorMessage)
            , headerColor: ConsoleColor.Red);

        CloseConsole(-1);
    }

    private static void CloseConsole(int errorCode)
    {
        Console.WriteLine("Press any key to close the console ...");
        Console.ReadKey();
        Environment.Exit(errorCode);
    }
}