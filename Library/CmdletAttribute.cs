using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CmdletAttribute : Attribute
    {
        public virtual string Command { get; set; }
    }
}
