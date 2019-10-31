using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                case Operation.Read:
                    Command = EnumHelper.GetCommand(Cmdlet.ReadRG);
                    break;
                case Operation.Update:
                    Command = EnumHelper.GetCommand(Cmdlet.UpdateRG);
                    break;
                case Operation.Delete:
                    Command = EnumHelper.GetCommand(Cmdlet.DeleteRG);
                    break;
                // Already done
                case Operation.Create:
                default:
                        break;
            }

            AddArgument(arg_resourcegroupname, Helper.AddQuotes(name));
        }

        public static bool MatchNamePattern(string name)
        {
            Regex regex = new Regex(NAME_PATTERN);
            if (regex.Matches(name).Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
