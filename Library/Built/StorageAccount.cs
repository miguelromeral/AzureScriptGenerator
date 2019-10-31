using Library.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Built
{
    public class StorageAccount : Statement
    {
        public static string ACCOUNTNAME = "-AccountName";
        public static string SKUNAME = "-SkuName";
        public static string NAME_PATTERN = @"^[a-zA-Z0-9]{3,24}$";

        public StorageAccount(Operation operation, string rg, string name, SKU sku, string location) :
            base(EnumHelper.GetCommand(Cmdlet.CreateSA))
        {
            switch (operation)
            {
                //case Operation.Read:
                //    Command = EnumHelper.GetCommand(Cmdlet.ReadRG);
                //    break;
                //case Operation.Update:
                //    Command = EnumHelper.GetCommand(Cmdlet.UpdateRG);
                //    break;
                //case Operation.Delete:
                //    Command = EnumHelper.GetCommand(Cmdlet.DeleteRG);
                //    break;
                //// Already done
                case Operation.Create:
                default:
                    break;
            }

            AddArgument(Argument.RESOURCEGROUP_NAME, Helper.AddQuotes(rg));
            AddArgument(ACCOUNTNAME, Helper.AddQuotes(name));
            AddArgument(SKUNAME, sku.ToString());
            AddArgument(Argument.LOCATION, Helper.AddQuotes(location));
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
