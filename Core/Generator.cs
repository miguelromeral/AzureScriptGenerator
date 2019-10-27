using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Built;
using Core.Statements;

namespace Core
{
    public static class Generator
    {
        public static Statement InstallModule_AzureRM()
        {
            var cl = new Statement(Generator.GetCmdletCommand(Cmdlet.InstallModule), "AzureRM");
            cl.AddArgument("-Force");
            return cl;
        }

        public static List<Command> CheckIfModuleExists(string module, string variablename, bool installifnot = true)
        {
            var assign = new Assignment(variablename, module)
            {
                Comment = "We check if the module " + module + " exists."
            };
            var variable = assign.Variable.ToString();

            var lista = new List<Command>();
            lista.Add(assign);

            var command = new Statement("Get-Module");
            command.AddArgument(new Argument("-ListAvailable"));
            command.AddArgument(new Argument("-Name", variable));

            var cond = new ConditionalIf(command)
            {
                Negate = true
            };

            if (installifnot)
            {
                cond.AddTrueStatement(new WriteHost("Installing the module '"+module+"'."));
                cond.AddTrueStatement(new Statement(Generator.GetCmdletCommand(Cmdlet.InstallModule), variable));
            }
            else
            {
                cond.AddTrueStatement(new WriteHost("The module '" + module + "' is not installed in this machine."));
            }

            cond.AddFalseStatement(new WriteHost("Tthe module '" + module + "' is already installed."));
            lista.Add(cond);

            return lista;
        }




        public static string GetCmdletCommand(Cmdlet value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                var attribute = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute));
                return attribute.Description;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
