using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Statements
{
    public class Variable
    {
        public string Name { get; set; }

        public Variable(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return "$" + Name;
        }
    }
}
