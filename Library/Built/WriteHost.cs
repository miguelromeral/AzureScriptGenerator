using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Built
{
    public class WriteHost : Statement
    {
        public WriteHost(string text) : base(EnumHelper.GetCommand(Cmdlet.WriteHost))
        {
            Value = "\"" + text + "\"";
        }
    }
}
