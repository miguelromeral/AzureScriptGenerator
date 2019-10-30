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
        public static string arg_resourcegroupname = "-Name";
        
        public static string NAME_PATTERN = @"^[-\w\._\(\)]+$";


        public ResourceGroup(Operation operation, string name) : base(EnumHelper.GetCommand(Cmdlet.CreateRG))
        {
            switch (operation)
            {
                case Operation.Remove:
                    Command = EnumHelper.GetCommand(Cmdlet.RemoveRG);
                    break;
                // Already done
                case Operation.Create:
                default:
                        break;
            }

            AddArgument(arg_resourcegroupname, name);
        }
    }
}
