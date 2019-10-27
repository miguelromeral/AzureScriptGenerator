using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Built
{
    public class WriteHost : Statement
    {
        public WriteHost(string text) : base(Generator.GetCmdletCommand(Cmdlet.WriteHost))
        {
            Value = "\"" + text + "\"";
        }
    }
}
