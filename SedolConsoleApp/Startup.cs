using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Sedol.Interfaces;
using Sedol.Validator;

namespace Sedol.RunnerApp
{
    public class Startup
    {
        public static IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                    .AddScoped<ISedolValidator, SedolValidator>()
                    .AddScoped<ISedolValidationResult, SedolValidationResult>()
                    .AddScoped<ISedolCaller, SedolCaller>()
                    .BuildServiceProvider();
        }
    }
}
