using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateConsoleApp.ArgParser;

[Verb("verb", HelpText = "Text to explain the verb")]
public class Verb1
{
    [Option(shortName: 'a', longName: "option", Required = false, HelpText = "Text to explain the option")]
    public string Option1 { get; set; }

    [Usage(ApplicationAlias = "app")]
    public static IEnumerable<Example> Examples
    {
        get
        {
            return new List<Example>()
            {
                new Example("Example 1", new Verb1 { Option1 = "value" }),
                new Example("Example 2", new Verb1 { Option1 = "value" })
            };
        }
    }
}