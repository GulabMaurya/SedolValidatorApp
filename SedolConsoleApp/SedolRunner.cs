using StructureMap;
using StructureMap.Graph;
using Sedol.Interfaces;
using Sedol.Validator;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sedol.RunnerApp
{
    public class SedolRunner
    {
        static void Main(string[] args)
        {
            var container = Startup.ConfigureServices();
            var app = container.GetService<ISedolCaller>();

            Console.WriteLine("Please enter the SEDOL:");
            string input = Console.ReadLine();

           var result = app.CallValidator(input);

            Console.WriteLine("Entered String: " + result.InputString.ToString());
            Console.WriteLine("IsValidSedol: " + result.IsValidSedol.ToString());
            Console.WriteLine("IsUserDefined: " + result.IsUserDefined.ToString());

            if (!string.IsNullOrEmpty(result.ValidationDetails))
                Console.WriteLine("Validation Details: " + result.ValidationDetails.ToString());
            else
                Console.WriteLine("Validation Details: null or empty");
            Console.ReadLine();
        }
    }
}
