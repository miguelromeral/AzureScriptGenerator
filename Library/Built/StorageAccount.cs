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
        public static string TYPE = "-Type";
        public static string NAME_PATTERN = @"^[a-zA-Z0-9]{3,24}$";

        public StorageAccount(string rg, string name, SKU sku, string location) :
            base(EnumHelper.GetCommand(Cmdlet.CreateSA))
        {
            AddArgument(Argument.RESOURCEGROUP_NAME, Helper.AddQuotes(rg));
            AddArgument(ACCOUNTNAME, Helper.AddQuotes(name));
            AddArgument(SKUNAME, sku.ToString());
            AddArgument(Argument.LOCATION, Helper.AddQuotes(location));
        }

        public StorageAccount(Operation operation, string rg, string name) :
            base(EnumHelper.GetCommand(Cmdlet.DeleteSA))
        {

            switch (operation)
            {
                case Operation.Read:
                    Command = EnumHelper.GetCommand(Cmdlet.ReadSA);
                    break;
                case Operation.Update:
                    Command = EnumHelper.GetCommand(Cmdlet.UpdateSA);
                    break;
                case Operation.Delete:
                    Command = EnumHelper.GetCommand(Cmdlet.DeleteSA);
                    break;
                default:
                    break;
            }

            AddArgument(Argument.RESOURCEGROUP_NAME, Helper.AddQuotes(rg));
            AddArgument(ACCOUNTNAME, Helper.AddQuotes(name));
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
