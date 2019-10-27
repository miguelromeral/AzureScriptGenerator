using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.cmdlets;
using Core.ControlStructures;

namespace Core
{
    public static class Library
    {
        public static Install_Module InstallModule_AzureRM()
        {
            var cl = new Install_Module("AzureRM");
            cl.SetForce();
            return cl;
        }

        public static ConditionalIf CheckIfModuleExists(string module, bool installifnot = true)
        {
            var command = new Cmdlet("Get-Module");
            command.AddArgument(new Argument("-ListAvailable"));
            command.AddArgument(new Argument("-Name", module));

            var cond = new ConditionalIf(command);

            if (installifnot)
            {
                cond.AddFalseStatement(new Cmdlet("Install-Module", module));
            }

            return cond;
        }
    }
}
