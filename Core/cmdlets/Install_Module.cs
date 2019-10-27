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
        public Install_Module(string module) : base()
        {
            Command = "Install-Module";
            Value = module;
        }

        public void SetForce()
        {
            Arguments.Add(new Argument("-Force"));
        }
    }
}
