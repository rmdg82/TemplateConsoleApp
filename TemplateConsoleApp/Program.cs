using CommandLine;
using TemplateConsoleApp.ArgParser;

namespace TemplateConsoleApp;

internal class Program
{
    internal static async Task Main(string[] args)
    {
        ArgsOptions parsedArgs = ParseArgs(args);

        await App.Configure(parsedArgs).RunAsync();
    }

    private static ArgsOptions ParseArgs(string[] args)
    {
        ArgsOptions result = null;

        Parser.Default.ParseArguments<ArgsOptions>(args)
            .WithParsed(opt => { result = opt; })
            .WithNotParsed(errors => Environment.Exit(-1));

        return result;
    }
}