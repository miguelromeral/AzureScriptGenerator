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
using Library.Azure;
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
            if (!ResourceGroup.MatchNamePattern(name))
                return null;

            var rg = new ResourceGroup(Operation.Create, name);
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

        public static ResourceGroup ReadResourceGroup(string name, string location = "")
        {
            if (!ResourceGroup.MatchNamePattern(name))
                return null;

            var rg = new ResourceGroup(Operation.Read, name);

            if (!String.IsNullOrEmpty(location))
            {
                rg.AddArgument(Argument.LOCATION, Helper.AddQuotes(location));
            }
            return rg;
        }

        public static ResourceGroup UpdateResourceGroup(string name)
        {
            if (!ResourceGroup.MatchNamePattern(name))
                return null;

            var rg = new ResourceGroup(Operation.Update, name);
            return rg;
        }

        public static ResourceGroup DeleteResourceGroup(string name, bool force = false)
        {
            if (!ResourceGroup.MatchNamePattern(name))
                return null;

            var rg = new ResourceGroup(Operation.Delete, name);
            if (force)
            {
                rg.AddArgument(Argument.FORCE);
            }
            return rg;
        }

        public static StorageAccount CreateStorageAccount(string resourcegroup, string name, SKU sku, string location)
        {
            if (!ResourceGroup.MatchNamePattern(resourcegroup) || !StorageAccount.MatchNamePattern(name))
                return null;

            var sa = new StorageAccount(Operation.Create, resourcegroup, name, sku, location);
            return sa;
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
