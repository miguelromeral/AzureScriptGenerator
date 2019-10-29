using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Built
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/new-azurermresourcegroup?view=azurermps-6.13.0
    /// </summary>
    public class ResourceGroup : Statement
    {
        public static string arg_resourcegroupname = "-ResourceGroupName";

        public ResourceGroup(string name) : base(EnumHelper.GetCommand(Cmdlet.NewRG))
        {
            AddArgument(arg_resourcegroupname, name);
        }
    }
}
