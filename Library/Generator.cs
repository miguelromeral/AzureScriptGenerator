using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library;
using Library.Built;
using Library.Statements;

namespace Library
{
    public static class Generator
    {
        public static Statement InstallModule_AzureRM()
        {
            var cl = new Statement(EnumHelper.GetCommand(Cmdlet.InstallModule), "AzureRM");
            cl.AddArgument("-Force");
            return cl;
        }

        public static ResourceGroup CreateResourceGroup(string name, bool force = false, string location = "")
        {
            Regex regex = new Regex(ResourceGroup.NAME_PATTERN);
            if (regex.Matches(name).Count == 0)
            {
                return null;
            }

            var rg = new ResourceGroup(Operation.Create, Helper.AddQuotes(name));
            if (force)
            {
                rg.AddArgument(Argument.FORCE);
            }
            if (!String.IsNullOrEmpty(location))
            {
                rg.AddArgument(Argument.LOCATION, Helper.AddQuotes(location));
            }
            return rg;
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
                cond.AddTrueStatement(new Statement(EnumHelper.GetCommand(Cmdlet.InstallModule), variable));
            }
            else
            {
                cond.AddTrueStatement(new WriteHost("The module '" + module + "' is not installed in this machine."));
            }

            cond.AddFalseStatement(new WriteHost("Tthe module '" + module + "' is already installed."));
            lista.Add(cond);

            return lista;
        }
        
    }
}
