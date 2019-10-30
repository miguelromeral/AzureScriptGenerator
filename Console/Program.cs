using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Statements;
using Library.Built;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var script = new Script()
            {
                Author = "ASG.Console",
                Description = "Script test"
            };

            var ifelse = Generator.CheckIfModuleExists("AzureRM", "azurerm", true);
            script.AddCommand(ifelse);
            script.AddCommand(new Statement("Login-AzureRMAccount"));
            script.AddCommand(new ResourceGroup(Operation.Create, "testing"));


            System.Console.WriteLine(script);



            System.Console.ReadKey();
        }
    }
}
