using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateConsoleApp.Services.Interfaces;

namespace TemplateConsoleApp.Services.Implementations;

public class Service1 : IService1
{
    public string MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task Method1(string config)
    {
        throw new NotImplementedException();
    }
}