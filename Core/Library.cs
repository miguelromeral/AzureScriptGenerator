using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.cmdlets;

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
    }
}
