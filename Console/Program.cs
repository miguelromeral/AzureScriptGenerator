﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.ControlStructures;

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

            var ifelse = Generator.CheckIfModuleExists("AzureRM", true);
            script.AddCommand(ifelse);
            script.AddCommand(new Statement("Login-AzureRMAccount"));

            System.Console.WriteLine(script);



            System.Console.ReadKey();
        }
    }
}
