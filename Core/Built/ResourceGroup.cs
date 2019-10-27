using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Built
{
    public class ResourceGroup : Statement
    {
        public static string arg_resourcegroupname = "-ResourceGroupName";

        public ResourceGroup(string name) : base(Generator.GetCmdletCommand(Cmdlet.NewRG))
        {
            AddArgument(arg_resourcegroupname, name);
        }
    }
}
