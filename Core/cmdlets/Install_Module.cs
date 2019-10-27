using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.cmdlets
{
    public class Install_Module : Cmdlet
    {
        public Install_Module(string module) : base("Install-Module")
        {
            Value = module;
        }

        public void SetForce()
        {
            AddArgument(new Argument("-Force"));
        }
    }
}
