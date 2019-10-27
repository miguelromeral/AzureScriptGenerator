using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.cmdlets
{
    public class Login_AzureRMAccount : Cmdlet
    {
        public Login_AzureRMAccount() : base()
        {
            Command = "Login-AzureRMAccount";
        }
    }
}
