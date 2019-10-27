using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.cmdlets;
using Core.ControlStructures;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var script = new Script() {
                Author = "ASG.Console",
                Description = "Script test"
            };

            var ifelse = Library.CheckIfModuleExists("AzureRM", true);
            ifelse.AddTrueStatement(new Cmdlet("Login-AzureRMAccount"));
            script.AddCommand(ifelse);

            System.Console.WriteLine(script);
            System.Console.ReadKey();
        }
    }
}
