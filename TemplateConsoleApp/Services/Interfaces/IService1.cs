using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateConsoleApp.Services.Interfaces;

public interface IService1
{
    public string MyProperty { get; set; }

    Task Method1(string config);
}