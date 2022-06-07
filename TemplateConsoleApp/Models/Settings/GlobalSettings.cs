using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateConsoleApp.ArgParser;

namespace TemplateConsoleApp.Models.Settings;

/// <summary>
/// Maps
/// </summary>
public class GlobalSettings
{
    public AppSettings? AppSettings { get; set; }
    public int MyProperty1 { get; private set; }
    public string? MyProperty2 { get; private set; }

    /// <summary>
    /// Set the global app variables
    /// </summary>
    /// <param name="options"></param>
    public void Set(ArgsOptions options)
    {
    }
}