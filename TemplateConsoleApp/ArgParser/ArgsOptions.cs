using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateConsoleApp.ArgParser;

public class ArgsOptions
{
    [Option(shortName: 'a', longName: "option1", Required = false, HelpText = "Text to explain the option")]
    public string Option1 { get; set; }
}