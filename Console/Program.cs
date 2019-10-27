using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.cmdlets;

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

            script.AddCommand(Library.InstallModule_AzureRM());
            script.AddCommand(new Login_AzureRMAccount());

            System.Console.WriteLine(script);
        }
    }
}
