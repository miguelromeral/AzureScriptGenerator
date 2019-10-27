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
            var script = new Script();
            var cl = new Install_Module("AzureRM");
            cl.SetForce();

            script.AddCommand(cl);
            
            System.Console.WriteLine(script);
        }
    }
}
